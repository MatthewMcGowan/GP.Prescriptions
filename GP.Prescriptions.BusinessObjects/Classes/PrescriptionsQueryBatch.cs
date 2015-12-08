namespace GP.Prescriptions.BusinessObjects.Classes
{
    using System;
    using System.Collections.Generic;
    using Queries.Interfaces;
    using Extensions;
    using System.Linq;

    /// <summary>
    /// Object to contain queries to be executed in one batch.
    /// Currently makes the assumption that you would not want to query
    /// using different Practices objects.
    /// TODO: Remove said assumption.
    /// </summary>
    public class PrescriptionsQueryBatch
    {
        #region Properties

        /// <summary>
        /// The CalcAvgCostByCode queries.
        /// </summary>
        public Dictionary<string, ICalcAvgCostByCode> calcAvgCostByCodes;

        /// <summary>
        /// The ICalcAvgCostByCodeByRegion queries.
        /// </summary>
        private Dictionary<Tuple<Region, string>, ICalcAvgCostByCodeByRegion> calcAvgCostByCodeByRegions;

        /// <summary>
        /// The ICalcTotalSpendPerPostcode query.
        /// </summary>
        private ICalcTotalActCostPerPostcode calcTotalSpendPerPostcode;

        /// <summary>
        /// The calculate total act cost by code by regions.
        /// </summary>
        private Dictionary<Tuple<Region, string>, ICalcTotalActCostByCodeByRegion> calcTotalActCostByCodeByRegions;

        /// <summary>
        /// The calculate total nic by code by region.
        /// </summary>
        private Dictionary<Tuple<Region, string>, ICalcTotalNicByCodeByRegion> calcTotalNicByCodeByRegion;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsQueryBatch"/> class.
        /// </summary>
        public PrescriptionsQueryBatch()
        {
            // Initialise objects
            calcAvgCostByCodes = new Dictionary<string, ICalcAvgCostByCode>();
            calcAvgCostByCodeByRegions = new Dictionary<Tuple<Region, string>, ICalcAvgCostByCodeByRegion>();
            calcTotalActCostByCodeByRegions = new Dictionary<Tuple<Region, string>, ICalcTotalActCostByCodeByRegion>();
            calcTotalNicByCodeByRegion = new Dictionary<Tuple<Region, string>, ICalcTotalNicByCodeByRegion>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the queries.
        /// </summary>
        /// <value>
        /// The queries.
        /// </value>
        public List<IPrescriptionsQuery> Queries
        {
            get
            {
                // Create list to return
                var qList = new List<IPrescriptionsQuery>();

                // Add all queries
                calcAvgCostByCodes.Where(q => q.Value != null).ForEach(q => qList.Add(q.Value));
                calcAvgCostByCodeByRegions.Where(q => q.Value != null).ForEach(q => qList.Add(q.Value));
                calcTotalActCostByCodeByRegions.Where(q => q.Value != null).ForEach(q => qList.Add(q.Value));
                calcTotalNicByCodeByRegion.Where(q => q.Value != null).ForEach(q => qList.Add(q.Value));
                if (calcTotalSpendPerPostcode != null) { qList.Add(calcTotalSpendPerPostcode); }

                // Return the list
                return qList;
            }
        }

        #endregion

        #region Public Methods

        #region TryAdd

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>True if added, false if already added.</returns>
        public bool TryAdd(ICalcAvgCostByCode query)
        {
            // If we already have a key, return false
            if (calcAvgCostByCodes.ContainsKey(query.BnfCode))
            {
                return false;
            }

            // Otherwise add
            calcAvgCostByCodes.Add(query.BnfCode, query);
            return true;
        }

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>True if added, false if already added.</returns>
        public bool TryAdd(ICalcAvgCostByCodeByRegion query)
        {
            // Create the dictionary key
            var key = new Tuple<Region, string>(query.Region, query.BnfCode);

            // Check if already in dictionary
            if (calcAvgCostByCodeByRegions.ContainsKey(key))
            {
                return false;
            }

            // Add to dictionary
            calcAvgCostByCodeByRegions.Add(key, query);
            return true;
        }

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>True if added, false if already added.</returns>
        public bool TryAdd(ICalcTotalActCostPerPostcode query)
        {
            // Check not already set
            if (calcTotalSpendPerPostcode == null)
            {
                return false;
            }

            calcTotalSpendPerPostcode = query;
            return true;
        }

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>True if added, false if already added.</returns>
        public bool TryAdd(ICalcTotalActCostByCodeByRegion query)
        {
            // Create key
            var key = new Tuple<Region, string>(query.Region, query.BnfCode);

            // Check if key already in dictionary
            if (calcTotalActCostByCodeByRegions.ContainsKey(key))
            {
                return false;
            }

            // Add to dictionary
            calcTotalActCostByCodeByRegions.Add(key, query);
            return true;
        }

        /// <summary>
        /// Adds the specified query.
        /// </summary>
        /// <param name="query">The query.</param>
        /// <returns>True if added, false if already added.</returns>
        public bool TryAdd(ICalcTotalNicByCodeByRegion query)
        {
            // Create key
            var key = new Tuple<Region, string>(query.Region, query.BnfCode);

            // Check if key already in dictionary
            if (calcTotalNicByCodeByRegion.ContainsKey(key))
            {
                return false;
            }

            // Add to dictionary
            calcTotalNicByCodeByRegion.Add(key, query);
            return true;
        }

        #endregion

        #region Get

        /// <summary>
        /// Gets the CalcAvgCostByCode query.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The CalcAvgCostByCode query</returns>
        public ICalcAvgCostByCode GetCalcAvgCostByCode(string bnfCode)
        {
            return calcAvgCostByCodes[bnfCode];
        }

        /// <summary>
        /// Gets the CalcAvgCostByCodeByRegion query.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The CalcAvgCostByCodeByRegion query</returns>
        public ICalcAvgCostByCodeByRegion GetCalcAvgCostByCodeByRegion(Region region, string bnfCode)
        {
            var key = new Tuple<Region, string>(region, bnfCode);
            return calcAvgCostByCodeByRegions[key];
        }

        /// <summary>
        /// Gets the the CalcTotalSpendPerPostcode query..
        /// </summary>
        /// <returns>The CalcTotalSpendPerPostcode query.</returns>
        public ICalcTotalActCostPerPostcode GetCalcTotalSpendPerPostcode()
        {
            return calcTotalSpendPerPostcode;
        }

        /// <summary>
        /// Gets the CalcAvgNicByCodeByRegion queries.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The CalcAvgNicByCodeByRegion queries</returns>
        public ICalcTotalActCostByCodeByRegion GetCalcTotalActCostByCodeByRegion(Region region, string bnfCode)
        {
            var key = new Tuple<Region, string>(region, bnfCode);
            return calcTotalActCostByCodeByRegions[key];
        }

        /// <summary>
        /// Gets the CalcAvgNicByCodeByRegion queries.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The CalcAvgNicByCodeByRegion queries</returns>
        public ICalcTotalNicByCodeByRegion GetCalcTotalNicByCodeByRegion(Region region, string bnfCode)
        {
            var key = new Tuple<Region, string>(region, bnfCode);
            return calcTotalNicByCodeByRegion[key];
        }

        #endregion

        #endregion
    }
}

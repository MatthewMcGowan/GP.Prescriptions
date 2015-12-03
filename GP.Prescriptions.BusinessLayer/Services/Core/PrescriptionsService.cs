﻿namespace GP.Prescriptions.BusinessLayer.Services.Core
{
    using System.Collections.Generic;

    using Interfaces;
    using BusinessObjects.Classes;
    using DataAccess.Readers.Core;
    using DataAccess.Readers.Interfaces;

    using ICalcAvgCostByCodeByRegion = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCodeByRegion;
    using IPrescriptionsQueryFactory = GP.Prescriptions.BusinessObjects.Queries.Interfaces.IPrescriptionsQueryFactory;
    using PrescriptionsQueryFactory = GP.Prescriptions.BusinessObjects.Queries.Core.PrescriptionsQueryFactory;

    /// <summary>
    /// A business service obtaining data about prescriptions.
    /// </summary>
    /// <seealso cref="IPrescriptionsService" />
    public class PrescriptionsService : IPrescriptionsService
    {
        #region Private Fields

        private readonly IPrescriptionsCsvReader prescriptionsReader;
        private readonly IPrescriptionsQueryFactory QueryFactory;

        private readonly Practices practices;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService"/> class.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <param name="prescriptionsReader">The prescriptions reader.</param>
        public PrescriptionsService(Practices practices, IPrescriptionsCsvReader prescriptionsReader, 
            IPrescriptionsQueryFactory QueryFactory)
        {
            // Set objects
            this.practices = practices;
            this.prescriptionsReader = prescriptionsReader;
            this.QueryFactory = QueryFactory;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService"/> class.
        /// </summary>
        public PrescriptionsService(Practices practices) 
            : this (practices, new PrescriptionsCsvReader(), new PrescriptionsQueryFactory())
        {
        }

        #endregion

        #region Public Methods

        public void GetAllAnalysis()
        {

        }

        /// <summary>
        /// Gets the average actual cost of a prescription by BNF code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>Average cost.</returns>
        public decimal GetAverageActCost(string bnfCode)
        {
            // Create query
            var query = QueryFactory.CalcAvgCostByCode(bnfCode);

            // Query csv reader
            prescriptionsReader.ExecuteQuery(query);

            // Return the result
            return query.Result;
        }

        /// <summary>
        /// Gets the total spend per postcode.
        /// </summary>
        /// <returns>Total spend for each postcode.</returns>
        public Dictionary<string, decimal> GetTotalSpendPerPostcode()
        {
            // Create query, passing the practices list
            var query = QueryFactory.CalcTotalSpendPerPostcode(practices);

            // Query with csv
            prescriptionsReader.ExecuteQuery(query);

            // Return result
            return query.Result;
        }

        /// <summary>
        /// Gets the average actual cost of a prescription for each region by BNF code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The average cost for each region.</returns>
        public Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode)
        {
            // Create list
            var queries = new List<ICalcAvgCostByCodeByRegion>();

            // Create query for each region
            Region.All.ForEach(r => queries.Add(
                QueryFactory.CalcAvgCostByCodeByRegion(bnfCode, r, practices)));

            // Query csv file
            prescriptionsReader.ExecuteQuery(queries);

            // Return the results
            var retDictionary = new Dictionary<Region, decimal>();
            queries.ForEach(q => retDictionary.Add(q.Region, q.Result));
            return retDictionary;
        }

        #endregion
    }
}

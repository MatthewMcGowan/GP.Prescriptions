namespace GP.Prescriptions.BusinessLayer.Services.Core
{
    using System.Collections.Generic;

    using Interfaces;
    using BusinessObjects.Classes;
    using DataAccess.Readers.Core;
    using DataAccess.Readers.Interfaces;
    using BusinessObjects.Queries.Interfaces;
    using BusinessObjects.Queries.Core;
    using BusinessObjects.Factories.Core;
    using BusinessObjects.Factories.Interfaces;

    /// <summary>
    /// A business service obtaining data about prescriptions.
    /// </summary>
    /// <seealso cref="IPrescriptionsService" />
    public class PrescriptionsService : IPrescriptionsService
    {
        #region Private Fields

        /// <summary>
        /// The prescriptions reader.
        /// </summary>
        private readonly IPrescriptionsCsvReader prescriptionsReader;

        /// <summary>
        /// The factory for prescription queries.
        /// </summary>
        private readonly IPrescriptionsQueryFactory queryFactory;

        /// <summary>
        /// The practices.
        /// </summary>
        private readonly Practices practices;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService" /> class.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <param name="prescriptionsReader">The prescriptions reader.</param>
        /// <param name="queryFactory">The query factory.</param>
        public PrescriptionsService(
            Practices practices,
            IPrescriptionsCsvReader prescriptionsReader,
            IPrescriptionsQueryFactory queryFactory)
        {
            // Set objects
            this.practices = practices;
            this.prescriptionsReader = prescriptionsReader;
            this.queryFactory = queryFactory;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService"/> class.
        /// </summary>
        public PrescriptionsService(Practices practices)
            : this(practices, new PrescriptionsCsvReader(), new PrescriptionsQueryFactory())
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the average actual cost of a prescription by BNF code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>Average cost.</returns>
        public decimal GetAverageActCost(string bnfCode)
        {
            // Create query
            var query = queryFactory.CalcAvgCostByCode(bnfCode);

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
            var query = queryFactory.CalcTotalSpendPerPostcode(practices);

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
            Region.All.ForEach(r => queries.Add(queryFactory.CalcAvgCostByCodeByRegion(bnfCode, r, practices)));

            // Query csv file
            prescriptionsReader.ExecuteQuery(queries);

            // Return the results
            var retDictionary = new Dictionary<Region, decimal>();
            queries.ForEach(q => retDictionary.Add(q.Region, q.Result));
            return retDictionary;
        }

        /// <summary>
        /// Gets the average Actual Cost as a decimal fraction of the average NIC for each region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>A fraction for each region.</returns>
        public Dictionary<Region, decimal> GetFractionActCostOfNicByRegion(string bnfCode)
        {
            // Get region count
            int regionCount = Region.All.Count;

            // Create new batch of queries to send to reader
            var queryBatch = new PrescriptionsQueryBatch();

            // Query the average Actual Cost for each region
            Region.All.ForEach(r => queryBatch.TryAdd(
                queryFactory.CalcTotalActCostByCodeByRegion(bnfCode, r, practices)));
            
            // Query the average NIC for each region
            Region.All.ForEach(r => queryBatch.TryAdd(
                queryFactory.CalcTotalNicByCodeByRegion(bnfCode, r, practices)));

            // Execute the queries using the reader
            prescriptionsReader.ExecuteQuery(queryBatch);

            // Calculate return dictionary
            var result = new Dictionary<Region, decimal>(regionCount);
            Region.All.ForEach(r => result.Add(r,
                queryBatch.GetCalcTotalActCostByCodeByRegion(r, bnfCode).Result
                / queryBatch.GetCalcTotalNicByCodeByRegion(r, bnfCode).Result));

            return result;
        }

            #endregion
        }
}

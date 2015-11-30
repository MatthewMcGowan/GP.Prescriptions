using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Core
{
    using DataAccess.Readers.Core;
    using DataAccess.Readers.Interfaces;
    using BusinessObjects.Classes;
    using Interfaces;
    using DataAccess.QueryTasks.Core;
    using DataAccess.QueryTasks.Interfaces;

    /// <summary>
    /// A business service obtaining data about prescriptions.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessLayer.Interfaces.IPrescriptionsService" />
    public class PrescriptionsService : IPrescriptionsService
    {
        #region Private Fields

        private readonly IPrescriptionsCsvReader prescriptionsReader;

        private readonly Practices practices;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService"/> class.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <param name="prescriptionsReader">The prescriptions reader.</param>
        public PrescriptionsService(Practices practices, IPrescriptionsCsvReader prescriptionsReader)
        {
            // Set DataAccess objects
            this.practices = practices;
            this.prescriptionsReader = prescriptionsReader;
        }

        /// <summary>
        /// Initialises a new instance of the <see cref="PrescriptionsService"/> class.
        /// </summary>
        public PrescriptionsService(Practices practices) : this (practices, new PrescriptionsCsvReader())
        {
        }

        #endregion

        #region Public Methods

        public void GetAllAnalysis()
        {

        }

        /// <summary>
        /// Gets the practice count by region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        public int GetPracticeCountByRegion(Region region)
        {
            return practices.Dictionary.Count(p => p.Value.Region == region.ToString());
        }

        /// <summary>
        /// Gets the average actual cost of a prescription by BNF code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>Average cost.</returns>
        public decimal GetAverageActCost(string bnfCode)
        {
            // Create query
            var query = new CalculateAverageActCostByBnfCode(bnfCode);

            // Query csv reader
            prescriptionsReader.ExecuteQueryTask(query);

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
            var query = new CalculateTotalSpendPerPostcode(practices);

            // Query with csv
            prescriptionsReader.ExecuteQueryTask(query);

            // Return result
            return query.Result;
        }

        /// <summary>
        /// Gets the average actual cost of a prescription by BNF code for a particular region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <returns>The average cost for a prescription for this region.</returns>
        public decimal GetAverageActCostByRegion(string bnfCode, Region region)
        {
            var query = new CalculateAverageActCostByBnfCodeByRegion(bnfCode, region, practices);
            prescriptionsReader.ExecuteQueryTask(query);
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
            var queries = new List<CalculateAverageActCostByBnfCodeByRegion>();

            // Create query for each region
            Region.All.ForEach(r => queries.Add(
                new CalculateAverageActCostByBnfCodeByRegion(bnfCode, r, practices)));

            // Query csv file
            prescriptionsReader.ExecuteQueryTask(queries);

            // Return the results
            var retDictionary = new Dictionary<Region, decimal>();
            queries.ForEach(q => retDictionary.Add(q.Region, q.Result));
            return retDictionary;
        }

        #endregion
    }
}

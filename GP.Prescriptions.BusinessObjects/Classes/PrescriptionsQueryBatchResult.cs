namespace GP.Prescriptions.BusinessObjects.Classes
{
    using System.Collections.Generic;

    public class PrescriptionsQueryBatchResult
    {
        #region Constructors

        public PrescriptionsQueryBatchResult()
        {
            // Initialise the result objects
            GetAverageActCostResults = new Dictionary<string, decimal>();
            GetTotalSpendPerPostcodeResults = new Dictionary<string, decimal>();
            GetAverageActCostPerRegionResults = new Dictionary<Region, decimal>();
            GetFractionActCostOfNicByRegionResults = new Dictionary<Region, decimal>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the get average act cost results.
        /// </summary>
        /// <value>
        /// The get average act cost results.
        /// </value>
        public Dictionary<string, decimal> GetAverageActCostResults { get; set; }

        /// <summary>
        /// Gets or sets the get total spend per postcode results.
        /// </summary>
        /// <value>
        /// The get total spend per postcode results.
        /// </value>
        public Dictionary<string, decimal> GetTotalSpendPerPostcodeResults { get; set; }

        /// <summary>
        /// Gets or sets the get average act cost per region results.
        /// </summary>
        /// <value>
        /// The get average act cost per region results.
        /// </value>
        public Dictionary<Region, decimal> GetAverageActCostPerRegionResults { get; set; }

        /// <summary>
        /// Gets or sets the get fraction act cost of nic by region results.
        /// </summary>
        /// <value>
        /// The get fraction act cost of nic by region results.
        /// </value>
        public Dictionary<Region, decimal> GetFractionActCostOfNicByRegionResults { get; set; }

        #endregion
    }
}

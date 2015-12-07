namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Classes;
    using Structs;
    using Interfaces;

    /// <summary>
    /// Query for calculating average cost by region for a particular prescription.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Core.BaseCalcAvgCostByCode" />
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCodeByRegion" />
    public class CalcAvgActCostByCodeByRegion : BaseCalcAvgCostByCode, ICalcAvgCostByCodeByRegion
    {
        #region Private Fields

        /// <summary>
        /// The practices.
        /// </summary>
        private readonly Practices practices;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalcAvgActCostByCodeByRegion"/> class.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        public CalcAvgActCostByCodeByRegion(string bnfCode, Region region, Practices practices) : base(bnfCode)
        {
            Region = region;
            this.practices = practices;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        public Region Region { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Processes the row.
        /// </summary>
        /// <param name="row">The row.</param>
        public override void ProcessRow(PrescriptionData row)
        {
            // Get region from practices
            string rowRegion = practices.GetPracticeRegionByPracticeCode(row.PracticeCode);

            // If row matches search criteria, add it
            if (row.BNFCode == BnfCode && rowRegion == Region.ToString())
            {
                TotalSold += row.Items;
                TotalCost += row.ActualCost;
            }
        }

        #endregion
    }
}

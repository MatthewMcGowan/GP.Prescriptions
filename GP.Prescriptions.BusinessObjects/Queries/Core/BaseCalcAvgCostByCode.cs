namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Structs;

    /// <summary>
    /// Base class for calculating average cost.
    /// </summary>
    public abstract class BaseCalcAvgCostByCode
    {
        #region Protected Fields

        /// <summary>
        /// The BNF code.
        /// </summary>
        protected readonly string BnfCode;

        /// <summary>
        /// The total sold.
        /// </summary>
        protected long TotalSold;

        /// <summary>
        /// The total cost.
        /// </summary>
        protected decimal TotalCost;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="BaseCalcAvgCostByCode"/> class.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        protected BaseCalcAvgCostByCode(string bnfCode)
        {
            this.BnfCode = bnfCode;

            TotalSold = 0L;
            TotalCost = 0M;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public decimal Result
        {
            get
            {
                return TotalSold > 0 ? TotalCost / TotalSold : 0M;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Processes the row.
        /// </summary>
        /// <param name="row">The row.</param>
        public virtual void ProcessRow(PrescriptionData row)
        {
            if (row.BNFCode == BnfCode)
            {
                TotalSold += row.Items;
                TotalCost += row.ActualCost;
            }
        }

        #endregion
    }
}

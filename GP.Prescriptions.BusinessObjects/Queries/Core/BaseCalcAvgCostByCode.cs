namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Structs;

    public abstract class BaseCalcAvgCostByCode
    {
        #region Protected Fields

        protected readonly string BnfCode;

        protected long TotalSold;
        protected decimal TotalCost;

        #endregion

        #region Constructors

        protected BaseCalcAvgCostByCode(string bnfCode)
        {
            this.BnfCode = bnfCode;

            TotalSold = 0L;
            TotalCost = 0M;
        }

        #endregion

        #region Public Properties

        public decimal Result
        {
            get
            {
                return TotalSold > 0 ? TotalCost / TotalSold : 0M;
            }
        }

        #endregion

        #region Public Methods

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

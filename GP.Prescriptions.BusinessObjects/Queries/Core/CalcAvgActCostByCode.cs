namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Interfaces;

    public class CalcAvgActCostByCode : BaseCalcAvgCostByCode, ICalcAvgCostByCode
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalcAvgActCostByCode"/> class.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        public CalcAvgActCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

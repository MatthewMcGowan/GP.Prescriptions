namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    public class CalcAvgCostByCode : BaseCalcAvgCostByCode, Interfaces.ICalcAvgCostByCode
    {
        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalcAvgCostByCode"/> class.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        public CalcAvgCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

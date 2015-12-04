namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    public class CalcAvgCostByCode : BaseCalcAvgCostByCode, Interfaces.ICalcAvgCostByCode
    {
        #region Constructors

        public CalcAvgCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

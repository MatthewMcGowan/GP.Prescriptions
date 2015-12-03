namespace GP.Prescriptions.BusinessObjects.QueryTasks.Core
{
    using ICalcAvgCostByCode = GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces.ICalcAvgCostByCode;

    public class CalcAvgCostByCode : BaseCalcAvgCostByCode, Interfaces.ICalcAvgCostByCode
    {
        #region Constructors

        public CalcAvgCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

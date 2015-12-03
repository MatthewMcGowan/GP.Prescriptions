namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using ICalcAvgCostByCode = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCode;

    public class CalcAvgCostByCode : BaseCalcAvgCostByCode, Interfaces.ICalcAvgCostByCode
    {
        #region Constructors

        public CalcAvgCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

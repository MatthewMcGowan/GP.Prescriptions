namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Classes;
    using Interfaces;

    public class CalcTotalActCostByCodeByRegion : BaseCalcTotalByCodeByRegion, ICalcTotalActCostByCodeByRegion
    {
        #region Constructors

        public CalcTotalActCostByCodeByRegion(string bnfCode, Region region, Practices practices)
            : base(bnfCode, region, practices)
        {
        }

        #endregion
    }
}

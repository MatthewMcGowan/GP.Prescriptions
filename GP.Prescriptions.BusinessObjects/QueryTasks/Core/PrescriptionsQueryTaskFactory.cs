namespace GP.Prescriptions.BusinessObjects.QueryTasks.Core
{
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces;

    using ICalcAvgCostByCode = GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces.ICalcAvgCostByCode;
    using ICalcAvgCostByCodeByRegion = GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces.ICalcAvgCostByCodeByRegion;
    using ICalcTotalSpendPerPostcode = GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces.ICalcTotalSpendPerPostcode;

    public class PrescriptionsQueryTaskFactory : IPrescriptionsQueryTaskFactory
    {
        public ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode)
        {
            return new CalcAvgCostByCode(bnfCode);
        }

        public ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices)
        {
            return new CalcAvgCostByCodeByRegion(bnfCode, region, practices);
        }

        public ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices)
        {
            return new CalcTotalSpendPerPostcode(practices);
        }
    }
}

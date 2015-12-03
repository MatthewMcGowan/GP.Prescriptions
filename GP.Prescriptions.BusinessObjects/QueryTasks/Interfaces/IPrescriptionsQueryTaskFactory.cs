namespace GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface IPrescriptionsQueryTaskFactory
    {
        ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode);

        ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices);

        ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices);
    }
}

namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface IPrescriptionsQueryFactory
    {
        ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode);

        ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices);

        ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices);
    }
}

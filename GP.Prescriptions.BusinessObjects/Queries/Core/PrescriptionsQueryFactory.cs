namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Classes;
    using Interfaces;

    public class PrescriptionsQueryFactory : IPrescriptionsQueryFactory
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

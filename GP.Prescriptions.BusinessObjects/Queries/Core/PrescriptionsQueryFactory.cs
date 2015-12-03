namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.BusinessObjects.Queries.Interfaces;

    using ICalcAvgCostByCode = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCode;
    using ICalcAvgCostByCodeByRegion = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCodeByRegion;
    using ICalcTotalSpendPerPostcode = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcTotalSpendPerPostcode;

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

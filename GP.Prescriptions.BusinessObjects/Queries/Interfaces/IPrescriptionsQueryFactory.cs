namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Classes;

    using GP.Prescriptions.BusinessObjects.Objects;

    public interface IPrescriptionsQueryFactory
    {
        /// <summary>
        /// Calculates the average cost by code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns></returns>
        ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode);

        /// <summary>
        /// Calculates the average cost by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices);

        /// <summary>
        /// Calculates the average nic by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcAvgCostByCodeByRegion CalcAvgNicByCodeByRegion(string bnfCode, Region region, Practices practices);

        /// <summary>
        /// Calculates the total spend per postcode.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices);
    }
}

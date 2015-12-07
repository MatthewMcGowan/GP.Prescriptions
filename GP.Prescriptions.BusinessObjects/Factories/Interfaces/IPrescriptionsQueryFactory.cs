namespace GP.Prescriptions.BusinessObjects.Factories.Interfaces
{
    using Classes;
    using Queries.Interfaces;

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
        /// Calculates the total spend per postcode.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcTotalActCostPerPostcode CalcTotalSpendPerPostcode(Practices practices);

        /// <summary>
        /// Calculates the total act cost by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcTotalActCostByCodeByRegion CalcTotalActCostByCodeByRegion(string bnfCode, Region region, Practices practices);

        /// <summary>
        /// Calculates the total nic by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        ICalcTotalNicByCodeByRegion CalcTotalNicByCodeByRegion(string bnfCode, Region region, Practices practices);
    }
}

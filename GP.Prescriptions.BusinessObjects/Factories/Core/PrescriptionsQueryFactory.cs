namespace GP.Prescriptions.BusinessObjects.Factories.Core
{
    using Classes;
    using Interfaces;
    using Queries.Interfaces;
    using Queries.Core;

    /// <summary>
    /// Factory to return a query object.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.IPrescriptionsQueryFactory" />
    public class PrescriptionsQueryFactory : IPrescriptionsQueryFactory
    {
        /// <summary>
        /// Calculates the average cost by code.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns></returns>
        public ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode)
        {
            return new CalcAvgActCostByCode(bnfCode);
        }

        /// <summary>
        /// Calculates the average cost by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        public ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices)
        {
            return new CalcAvgActCostByCodeByRegion(bnfCode, region, practices);
        }

        /// <summary>
        /// Calculates the average NIC by code by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <param name="region">The region.</param>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        public ICalcAvgNicByCodeByRegion CalcAvgNicByCodeByRegion(string bnfCode, Region region, Practices practices)
        {
            return new CalcAvgNicByCodeByRegion(bnfCode, region, practices);
        }

        /// <summary>
        /// Calculates the total spend per postcode.
        /// </summary>
        /// <param name="practices">The practices.</param>
        /// <returns></returns>
        public ICalcTotalActCostPerPostcode CalcTotalSpendPerPostcode(Practices practices)
        {
            return new CalcTotalActCostPerPostcode(practices);
        }
    }
}

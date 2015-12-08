namespace GP.Prescriptions.BusinessLayer.Services.Interfaces
{
    using System.Collections.Generic;
    using BusinessObjects.Classes;

    /// <summary>
    /// Interface for prescriptions business service.
    /// </summary>
    public interface IPrescriptionsService
    {
        /// <summary>
        /// Gets the average act cost.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>THe average actual cost.</returns>
        decimal GetAverageActCost(string bnfCode);

        /// <summary>
        /// Gets the total spend per postcode.
        /// </summary>
        /// <returns>The total spend for each postcode.</returns>
        Dictionary<string, decimal> GetTotalSpendPerPostcode();

        /// <summary>
        /// Gets the average act cost per region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The average actual cost per region.</returns>
        Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode);

        /// <summary>
        /// Gets the average Actual Cost as a fraction of the average NIC by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns>The decimal fraction of average Actual Cost to NIC.</returns>
        Dictionary<Region, decimal> GetFractionActCostOfNicByRegion(string bnfCode);

        /// <summary>
        /// Executes all queries.
        /// </summary>
        /// <param name="averageActCostBnfCode">The AverageActCostBnfCode BNF code.</param>
        /// <param name="averageActCostPerRegionBnfCode">The AverageActCostPerRegionBnfCode BNF code.</param>
        /// <param name="fractionActCostOfNicByRegionBnfCode">The FractionActCostOfNicByRegionBnfCode BNF code.</param>
        /// <returns></returns>
        PrescriptionsQueryBatchResult ExecuteAllQueries(
            string averageActCostBnfCode,
            string averageActCostPerRegionBnfCode,
            string fractionActCostOfNicByRegionBnfCode);
    }
}

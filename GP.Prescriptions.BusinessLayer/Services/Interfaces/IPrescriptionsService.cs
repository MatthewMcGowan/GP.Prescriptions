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
        /// <returns></returns>
        decimal GetAverageActCost(string bnfCode);

        /// <summary>
        /// Gets the total spend per postcode.
        /// </summary>
        /// <returns></returns>
        Dictionary<string, decimal> GetTotalSpendPerPostcode();

        /// <summary>
        /// Gets the average act cost per region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns></returns>
        Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode);

        /// <summary>
        /// Gets the average margin by region.
        /// </summary>
        /// <param name="bnfCode">The BNF code.</param>
        /// <returns></returns>
        Dictionary<Region, decimal> GetAverageMarginByRegion(string bnfCode);
    }
}

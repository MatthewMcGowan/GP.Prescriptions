namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Classes;

    /// <summary>
    /// Interface for CalcAvgCostByCodeByRegion.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.IPrescriptionsQuery" />
    public interface ICalcAvgCostByCodeByRegion : IPrescriptionsQuery
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        decimal Result { get; }

        /// <summary>
        /// Gets the region.
        /// </summary>
        /// <value>
        /// The region.
        /// </value>
        Region Region { get; }


        /// <summary>
        /// Gets the BNF code.
        /// </summary>
        /// <value>
        /// The BNF code.
        /// </value>
        string BnfCode { get; }
    }
}

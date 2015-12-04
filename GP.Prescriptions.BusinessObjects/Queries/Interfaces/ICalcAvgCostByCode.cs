namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    /// <summary>
    /// Interface for CalcAvgCostByCode.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.IPrescriptionsQuery" />
    public interface ICalcAvgCostByCode : IPrescriptionsQuery
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        decimal Result { get; }
    }
}

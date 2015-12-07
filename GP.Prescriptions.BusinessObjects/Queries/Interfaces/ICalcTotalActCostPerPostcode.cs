namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using System.Collections.Generic;

    /// <summary>
    /// Interface for CalcTotalSpendPerPostcode.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.IPrescriptionsQuery" />
    public interface ICalcTotalActCostPerPostcode : IPrescriptionsQuery
    {
        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        Dictionary<string, decimal> Result { get; }
    }
}

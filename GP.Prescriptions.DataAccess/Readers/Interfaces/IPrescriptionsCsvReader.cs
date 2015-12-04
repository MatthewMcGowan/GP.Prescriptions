namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Generic;

    using BusinessObjects.Queries.Interfaces;

    /// <summary>
    /// Interface for PrescriptionsCsvReader.
    /// </summary>
    public interface IPrescriptionsCsvReader
    {
        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
        void ExecuteQuery(IPrescriptionsQuery query);

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="queries">The queries.</param>
        void ExecuteQuery(IEnumerable<IPrescriptionsQuery> queries);
    }
}

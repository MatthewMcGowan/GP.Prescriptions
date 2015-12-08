namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Generic;
    using BusinessObjects.Queries.Interfaces;
    using BusinessObjects.Classes;

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
        /// Executes the queries.
        /// </summary>
        /// <param name="queries">The queries.</param>
        void ExecuteQuery(IEnumerable<IPrescriptionsQuery> queries);

        /// <summary>
        /// Executes the queries.
        /// </summary>
        /// <param name="batch">The batch.</param>
        void ExecuteQuery(PrescriptionsQueryBatch batch);
    }
}

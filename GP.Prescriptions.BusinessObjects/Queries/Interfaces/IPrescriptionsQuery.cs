namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Structs;

    /// <summary>
    /// Interface for PrescriptionsQuery.
    /// </summary>
    public interface IPrescriptionsQuery
    {
        /// <summary>
        /// Processes the row.
        /// </summary>
        /// <param name="row">The row.</param>
        void ProcessRow(PrescriptionData row);
    }
}

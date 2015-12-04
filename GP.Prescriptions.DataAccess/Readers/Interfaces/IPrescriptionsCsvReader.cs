namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Generic;

    using BusinessObjects.Queries.Interfaces;

    public interface IPrescriptionsCsvReader
    {
        void ExecuteQuery(IPrescriptionsQuery query);

        void ExecuteQuery(IEnumerable<IPrescriptionsQuery> queries);
    }
}

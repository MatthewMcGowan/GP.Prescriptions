using System.Collections.Generic;

namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Queries.Interfaces;

    public interface IPrescriptionsCsvReader
    {
        void ExecuteQuery(IPrescriptionsQuery query);

        void ExecuteQuery(IEnumerable<IPrescriptionsQuery> queries);
    }
}

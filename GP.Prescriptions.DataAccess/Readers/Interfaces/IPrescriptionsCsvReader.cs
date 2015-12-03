using System.Collections.Generic;

namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces;

    public interface IPrescriptionsCsvReader
    {
        void ExecuteQueryTask(IPrescriptionsQueryTask query);

        void ExecuteQueryTask(IEnumerable<IPrescriptionsQueryTask> queries);
    }
}

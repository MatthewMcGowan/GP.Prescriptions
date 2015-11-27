using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using GP.Prescriptions.DataAccess.QueryTasks.Interfaces;

    public interface IPrescriptionsCsvReader
    {
        void ExecuteQueryTask(IPrescriptionsQueryTask query);

        void ExecuteQueryTask(Dictionary<string, IPrescriptionsQueryTask> queries);
    }
}

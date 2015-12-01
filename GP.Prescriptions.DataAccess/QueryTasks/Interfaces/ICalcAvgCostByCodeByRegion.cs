using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Interfaces
{
    using BusinessObjects.Classes;

    public interface ICalcAvgCostByCodeByRegion : IPrescriptionsQueryTask
    {
        decimal Result { get; }

        Region Region { get; }
    }
}

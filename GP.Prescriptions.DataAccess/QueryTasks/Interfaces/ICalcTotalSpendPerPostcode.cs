using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Interfaces
{
    public interface ICalcTotalSpendPerPostcode : IPrescriptionsQueryTask
    {
        Dictionary<string, decimal> Result { get; }
    }
}

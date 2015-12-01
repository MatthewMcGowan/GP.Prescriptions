using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Interfaces
{
    using Core;
    using BusinessObjects.Classes;

    public interface IPrescriptionsQueryTaskFactory
    {
        ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode);

        ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices);

        ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices);
    }
}

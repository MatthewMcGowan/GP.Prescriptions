using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using Interfaces;
    using BusinessObjects.Classes;

    public class PrescriptionsQueryTaskFactory : IPrescriptionsQueryTaskFactory
    {
        public ICalcAvgCostByCode CalcAvgCostByCode(string bnfCode)
        {
            return new CalcAvgCostByCode(bnfCode);
        }

        public ICalcAvgCostByCodeByRegion CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices)
        {
            return new CalcAvgCostByCodeByRegion(bnfCode, region, practices);
        }

        public ICalcTotalSpendPerPostcode CalcTotalSpendPerPostcode(Practices practices)
        {
            return new CalcTotalSpendPerPostcode(practices);
        }
    }
}

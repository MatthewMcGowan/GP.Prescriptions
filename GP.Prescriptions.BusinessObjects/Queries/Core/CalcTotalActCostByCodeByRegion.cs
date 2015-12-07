using GP.Prescriptions.BusinessObjects.Classes;
using GP.Prescriptions.BusinessObjects.Queries.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    public class CalcTotalActCostByCodeByRegion : BaseCalcTotalByCodeByRegion, ICalcTotalActCostByCodeByRegion
    {
        #region Constructors

        public CalcTotalActCostByCodeByRegion(string bnfCode, Region region, Practices practices)
            : base(bnfCode, region, practices)
        {
        }

        #endregion
    }
}

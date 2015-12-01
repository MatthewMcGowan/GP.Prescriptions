using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using BusinessObjects.Structs;
    using Interfaces;

    public class CalcAvgCostByCode : BaseCalcAvgCostByCode, ICalcAvgCostByCode
    {
        #region Constructors

        public CalcAvgCostByCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

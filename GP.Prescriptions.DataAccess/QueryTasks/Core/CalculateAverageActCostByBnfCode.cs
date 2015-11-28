using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using BusinessObjects.Structs;
    using Interfaces;

    public class CalculateAverageActCostByBnfCode : BaseCalculateAverageActCostByBnfCode, IPrescriptionsQueryTask
    {
        #region Constructors

        public CalculateAverageActCostByBnfCode(string bnfCode) : base(bnfCode)
        {
        }

        #endregion
    }
}

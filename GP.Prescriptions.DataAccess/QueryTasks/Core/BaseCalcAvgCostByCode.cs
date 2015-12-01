using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using BusinessObjects.Structs;

    public abstract class BaseCalcAvgCostByCode
    {
        #region Protected Fields

        protected readonly string bnfCode;

        protected long totalSold;
        protected decimal totalCost;

        #endregion

        #region Constructors

        protected BaseCalcAvgCostByCode(string bnfCode)
        {
            this.bnfCode = bnfCode;

            totalSold = 0L;
            totalCost = 0M;
        }

        #endregion

        #region Public Properties

        public decimal Result
        {
            get
            {
                return totalCost / totalSold;
            }
        }

        #endregion

        #region Public Methods

        public virtual void ProcessRow(PrescriptionData row)
        {
            if (row.BNFCode == bnfCode)
            {
                totalSold += row.Items;
                totalCost += row.NIC;
            }
        }

        #endregion
    }
}

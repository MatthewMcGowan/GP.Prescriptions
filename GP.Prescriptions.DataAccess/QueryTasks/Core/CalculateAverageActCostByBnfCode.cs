using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using BusinessObjects.Structs;
    using Interfaces;

    public class CalculateAverageActCostByBnfCode : IPrescriptionsQueryTask
    {
        #region Private Fields

        private readonly string bnfCode;

        private long totalSold;
        private decimal totalCost;

        #endregion

        #region Constructors

        public CalculateAverageActCostByBnfCode(string bnfCode)
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

        public void ProcessRow(PrescriptionData row)
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

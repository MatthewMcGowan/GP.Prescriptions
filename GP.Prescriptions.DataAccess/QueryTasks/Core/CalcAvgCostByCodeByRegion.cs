using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Core
{
    using BusinessObjects.Classes;
    using BusinessObjects.Structs;
    using Interfaces;

    public class CalcAvgCostByCodeByRegion : BaseCalcAvgCostByCode, ICalcAvgCostByCodeByRegion
    {
        #region Private Fields

        private readonly Practices practices;

        #endregion

        #region Constructors

        public CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices) : base(bnfCode)
        {
            Region = region;
            this.practices = practices;
        }

        #endregion

        #region Public Properties

        public Region Region { get; private set; }

        #endregion

        #region Public Methods

        public override void ProcessRow(PrescriptionData row)
        {
            // Get region from practices
            string rowRegion = practices.GetPracticeRegionByPracticeCode(row.PracticeCode);

            // If row matches search criteria, add it
            if (row.BNFCode == bnfCode && rowRegion == Region.ToString())
            {
                totalSold += row.Items;
                totalCost += row.NIC;
            }
        }

        #endregion
    }
}

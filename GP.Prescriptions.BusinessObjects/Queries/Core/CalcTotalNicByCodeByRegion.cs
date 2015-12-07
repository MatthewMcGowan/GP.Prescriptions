using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using Classes;
    using Structs;
    using Interfaces;

    public class CalcTotalNicByCodeByRegion : BaseCalcTotalByCodeByRegion, ICalcTotalNicByCodeByRegion
    {
        #region Constructors

        public CalcTotalNicByCodeByRegion(string bnfCode, Region region, Practices practices)
            : base(bnfCode, region, practices)
        {
        }

        #endregion

        #region Public Methods

        public override void ProcessRow(PrescriptionData row)
        {
            // Get region from practices
            string rowRegion = Practices.GetPracticeRegionByPracticeCode(row.PracticeCode);

            // If row matches search criteria, add it
            if (row.BNFCode == BnfCode && rowRegion == Region.ToString())
            {
                total += row.NIC;
            }
        }

        #endregion
    }
}

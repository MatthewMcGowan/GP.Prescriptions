using GP.Prescriptions.BusinessObjects.Classes;
using GP.Prescriptions.BusinessObjects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    public abstract class BaseCalcTotalByCodeByRegion
    {
        #region Private/Protected Fields

        private readonly string bnfCode;

        private readonly Region region;

        private readonly Practices practices;

        protected decimal total;

        #endregion

        #region Constructors

        protected BaseCalcTotalByCodeByRegion(string bnfCode, Region region, Practices practices)
        {
            this.bnfCode = bnfCode;
            this.region = region;
            this.practices = practices;
        }

        #endregion

        #region Public Properties

        public string BnfCode { get { return bnfCode; } }

        public Region Region { get { return region; } }

        public Practices Practices { get { return practices; } }

        public decimal Result { get { return total; } }

        #endregion

        #region Public Methods

        public virtual void ProcessRow(PrescriptionData row)
        {
            // Get region from practices
            string rowRegion = Practices.GetPracticeRegionByPracticeCode(row.PracticeCode);

            // If row matches search criteria, add it
            if (row.BNFCode == BnfCode && rowRegion == Region.ToString())
            {
                total += row.ActualCost;
            }
        }

        #endregion
    }
}

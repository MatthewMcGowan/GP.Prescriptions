using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Structs
{
    public struct PrescriptionData
    {
        // Strategic Healthy Authority
        public string SHA;
        // Primary Care Trust
        public string PCT;
        public string PracticeCode;
        // British National Formulary
        public string BNFCode;
        public string BNFName;
        public int Items;
        // Net Ingredient Cost
        public decimal NIC;
        public decimal ActualCost;
        public string Period;
    }
}

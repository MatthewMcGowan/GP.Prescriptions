using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using Structs;
    using Moq;
    using Prescriptions.Test.Data;

    public abstract class BaseQueriesTests
    {
        #region Protected Fields

        protected PrescriptionData BnfCode1ValidRow1;
        protected PrescriptionData BnfCode1ValidRow2;
        protected PrescriptionData BnfCode1ZeroRow1;
        protected PrescriptionData BnfCode2ValidRow1;

        #endregion

        protected BaseQueriesTests()
        {
            PopulateRowData();
        }

        public void PopulateRowData()
        {
            BnfCode1ValidRow1 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.Items1,
                NIC = Data.Cost1,
                ActualCost = Data.Cost2,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            BnfCode1ValidRow2 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.Items2,
                NIC = Data.Cost2,
                ActualCost = Data.Cost3,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            BnfCode1ZeroRow1 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.ItemsZero,
                NIC = Data.CostZero,
                ActualCost = Data.CostZero,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            BnfCode2ValidRow1 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode2,
                Items = Data.Items1,
                NIC = Data.Cost1,
                ActualCost = Data.Cost1,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using NUnit.Framework;
    using Moq;
    using BusinessObjects.Queries.Core;
    using Prescriptions.Test.Data;
    using Classes;

    public class CalcTotalActCostByCodeByRegionTests : BaseQueriesTests
    {
        private CalcTotalActCostByCodeByRegion query;

        [SetUp]
        public void Setup()
        {
            query = new CalcTotalActCostByCodeByRegion(Data.BnfCode1, Region.London, Practices);
        }

        [Test]
        public void CalcTotalActCostByCodeByRegion_TwoRowsWithSameRegionAndBnfCode_CorrectValueCalculated()
        {
            // Process two rows with same region and BNF code
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowDifferentCosts);

            // Get result
            decimal result = query.Result;

            // Check rows added correctly
            Assert.AreEqual(Data.Cost2 + Data.Cost3, result);
        }

        [Test]
        public void CalcTotalActCostByCodeByRegion__RowWithOtherBnfCodeGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowBnfCode2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            Assert.AreEqual(Data.Cost2, result);
        }

        [Test]
        public void CalcTotalActCostByCodeByRegion_RowWithOtherRegionGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowPractice2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            Assert.AreEqual(Data.Cost2, result);
        }

        [Test]
        public void CalcTotalActCostByCodeByRegion_ZeroValuedRowGiven_ZeroValueReturned()
        {
            // Process with zero values
            query.ProcessRow(ZeroRow);

            // Get result
            decimal result = query.Result;

            // Check zero returned, without a System.DivideByZeroException
            Assert.AreEqual(0M, result);
        }
    }
}

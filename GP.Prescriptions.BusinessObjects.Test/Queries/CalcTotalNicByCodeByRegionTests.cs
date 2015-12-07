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

    public class CalcTotalNicByCodeByRegionTests : BaseQueriesTests
    {
        private CalcTotalNicByCodeByRegion query;

        [SetUp]
        public void Setup()
        {
            query = new CalcTotalNicByCodeByRegion(Data.BnfCode1, Region.London, Practices);
        }
        
        [Test]
        public void CalcTotalNicByCodeByRegion_TwoRowsWithSameRegionAndBnfCode_CorrectValueCalculated()
        {
            // Process two rows
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowDifferentCosts);

            // Get result
            decimal result = query.Result;

            // Check summed correctly
            Assert.AreEqual(Data.Cost1 + Data.Cost2, result);
        }

        [Test]
        public void CalcTotalNicByCodeByRegion_RowWithOtherBnfCodeGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowBnfCode2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            Assert.AreEqual(Data.Cost1, result);
        }

        [Test]
        public void CalcTotalNicByCodeByRegion_RowWithOtherRegionGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowPractice2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            Assert.AreEqual(Data.Cost1, result);
        }

        [Test]
        public void CalcTotalNicByCodeByRegion_ZeroValuedRowGiven_ZeroValueReturned()
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

namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using Classes;
    using BusinessObjects.Queries.Core;
    using Prescriptions.Test.Data;
    using NUnit.Framework;

    [TestFixture]
    public class CalcAvgCostByCodeByRegionTests : BaseQueriesTests
    {
        private CalcAvgActCostByCodeByRegion query;

        [SetUp]
        public void Setup()
        {
            query = new CalcAvgActCostByCodeByRegion(Data.BnfCode1, Region.London, Practices);
        }

        [Test]
        public void CalcAvgCostByCodeByRegion_TwoRowsWithSameRegionAndBnfCode_CorrectValueCalculated()
        {
            // Process two rows with queried Region and BNF code
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowDifferentCosts);

            // Get result
            decimal result = query.Result;

            // Check calculated correctly
            decimal expected = (Data.Cost2 + Data.Cost3) / (Data.Items1 + Data.Items2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalcAvgCostByCodeByRegion_RowWithOtherBnfCodeGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowBnfCode2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            decimal expected = Data.Cost2 / Data.Items1;
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalcAvgCostByCodeByRegion_RowWithOtherRegionGiven_OtherRegionRowIgnored()
        {
            // Process two rows with different BNF Codes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowPractice2);

            // Get result
            decimal result = query.Result;

            // Check only correct row processed
            decimal expected = Data.Cost2 / Data.Items1;
            Assert.AreEqual(expected, result);
        }


        [Test]
        public void CalcAvgCostByCodeByRegion_ZeroValuedRowGiven_ZeroValueReturned()
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

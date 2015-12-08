namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using NUnit.Framework;
    using BusinessObjects.Queries.Core;
    using Prescriptions.Test.Data;

    [TestFixture]
    public class CalcAvgCostByCodeTests : BaseQueriesTests
    {
        private CalcAvgActCostByCode query;

        [SetUp]
        public void Setup()
        {
            query = new CalcAvgActCostByCode(Data.BnfCode1);
        }

        [Test]
        public void CalcAvgCostByCode_TwoRowsWithSameBnfCode_CorrectValueCalculated()
        {
            // Process two rows with queried BNF Code
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowDifferentCosts);

            // Get result
            decimal result = query.Result;

            // Check calculated correctly
            decimal expected = (Data.Cost2 + Data.Cost3) / (Data.Items1 + Data.Items2);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void CalcAvgCostByCode_RowWithOtherBnfCodeGiven_OtherBnfCodeRowIgnored()
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
        public void CalcAvgCostByCode_ZeroValuedRowGiven_ZeroValueReturned()
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

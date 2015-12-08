namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using NUnit.Framework;
    using BusinessObjects.Queries.Core;
    using Prescriptions.Test.Data;

    [TestFixture]
    public class CalcTotalSpendPerPostcodeTests :BaseQueriesTests
    {
        private CalcTotalActCostPerPostcode query;

        [SetUp]
        public void Setup()
        {
            query = new CalcTotalActCostPerPostcode(Practices);
        }

        [Test]
        public void CalcTotalSpendPerPostcode__TwoRowsWithSamePostcode_CorrectValueCalculated()
        {
            // Process two rows with same postcode
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowDifferentCosts);

            // Get result
            var result = query.Result;

            // Check correct value calculated
            decimal expected = Data.Cost2 + Data.Cost3;
            Assert.AreEqual(expected, result[Data.Postcode1]);
        }

        [Test]
        public void CalcTotalSpendPerPostcode_RowWithOtherPostcodeGiven_OtherPostcodeRowIgnored()
        {
            // Process two rows with different postcodes
            query.ProcessRow(ValidRow);
            query.ProcessRow(ValidRowPractice2);

            // Get result
            var result = query.Result;

            // Check postcodes are independent
            Assert.AreEqual(Data.Cost2, result[Data.Postcode1]);
            Assert.AreEqual(Data.Cost2, result[Data.Postcode2]);
        }

        [Test]
        public void CalcTotalSpendPerPostcode_ZeroValuedRowGiven_ZeroValueReturned()
        {
            // Process zero valued row
            query.ProcessRow(ZeroRow);

            // Get result
            var result = query.Result;

            // Check zero result returned
            Assert.AreEqual(Data.CostZero, result[Data.Postcode1]);
        }
    }
}

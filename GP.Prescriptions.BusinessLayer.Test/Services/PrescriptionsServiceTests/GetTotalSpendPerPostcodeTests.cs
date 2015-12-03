namespace GP.Prescriptions.BusinessLayer.Test.Services.PrescriptionsServiceTests
{
    using System.Collections.Generic;

    using GP.Prescriptions.BusinessLayer.Services.Core;
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces;

    using Moq;

    using NUnit.Framework;

    public class GetTotalSpendPerPostcodeTests : BasePrescriptionsServiceTests
    {
        private Mock<ICalcTotalSpendPerPostcode> query;

        private Dictionary<string, decimal> regionSpends;

        [SetUp]
        public void Setup()
        {
            BaseSetup();
            query = new Mock<ICalcTotalSpendPerPostcode>();
            Practices = GetPractices();
        }

        [Test]
        public void GetTotalSpendPerPostcode_DictionaryReturnedFromDA_DictionaryReturned()
        {
            // Create dictionary to be returned
            regionSpends = new Dictionary<string, decimal>
                               {
                                   { Region.EastMidlands.ToString(), 5M },
                                   { Region.EastOfEngland.ToString(), 6M }
                               };
            // Mock query
            query.Setup(q => q.Result).Returns(regionSpends);
            QueryTaskFactory.Setup(f => f.CalcTotalSpendPerPostcode(Practices)).Returns(query.Object);
            // Mock reader
            PrescriptionsReader.Setup(r => r.ExecuteQueryTask(query.Object));
            // Instantiate service
            PrescriptionsService = new PrescriptionsService(Practices, PrescriptionsReader.Object, QueryTaskFactory.Object);

            // Call method
            var result = PrescriptionsService.GetTotalSpendPerPostcode();

            // Check data returned unchanged
            Assert.IsTrue(result[Region.EastMidlands.ToString()] == 5M && result[Region.EastOfEngland.ToString()] == 6M);
            Assert.AreEqual(regionSpends.Count, 2);
            // Check reader was called
            PrescriptionsReader.VerifyAll();
        }
    }
}

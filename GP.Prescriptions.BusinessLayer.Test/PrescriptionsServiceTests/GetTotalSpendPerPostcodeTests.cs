using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using GP.Prescriptions.BusinessLayer.Core;
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.DataAccess.QueryTasks.Interfaces;

    using NUnit.Framework;
    using Moq;

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

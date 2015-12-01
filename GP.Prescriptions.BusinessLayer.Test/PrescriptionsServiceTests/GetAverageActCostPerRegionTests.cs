using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.DataAccess.QueryTasks.Interfaces;
    using GP.Prescriptions.Test.Data;

    using NUnit.Framework;
    using Moq;
    using Core;

    using GP.Prescriptions.BusinessObjects.Extensions;

    public class GetAverageActCostPerRegionTests : BasePrescriptionsServiceTests
    {
        [SetUp]
        public void Setup()
        {
            BaseSetup();
            Practices = GetPractices();
        }

        [Test]
        public void GetAverageActCostPerRegion_ValidBnfCodeSupplied_CorrectResultsReturned()
        {
            // Mock the queries list
            decimal queryReturnValue = 0M;
            foreach (var r in Region.All)
            {
                var query = new Mock<ICalcAvgCostByCodeByRegion>();
                query.Setup(q => q.Region).Returns(r);
                query.Setup(q => q.Result).Returns(queryReturnValue++);
                QueryTaskFactory.Setup(
                    f => f.CalcAvgCostByCodeByRegion(Data.BnfCode1, It.Is<Region>(m => m.Equals(r)), Practices))
                    .Returns(query.Object);
            }
            // Mock reader
            PrescriptionsReader.Setup(r => r.ExecuteQueryTask(It.IsAny<List<ICalcAvgCostByCodeByRegion>>()));
            // Instantiate service
            PrescriptionsService = new PrescriptionsService(Practices, PrescriptionsReader.Object, QueryTaskFactory.Object);

            // Call method
            var result = PrescriptionsService.GetAverageActCostPerRegion(Data.BnfCode1);

            // Check returned list is correct
            decimal expectedReturnValue = 0M;
            Assert.AreEqual(result.Count(r => r.Value == expectedReturnValue++), Region.All.Count);
            Assert.AreEqual(result.Count, Region.All.Count);
            // Check DA called
            // PrescriptionsReader.VerifyAll();
        }
    }
}

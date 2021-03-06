﻿namespace GP.Prescriptions.BusinessLayer.Test.Services.PrescriptionsServiceTests
{
    using System.Collections.Generic;
    using System.Linq;
    using BusinessLayer.Services.Core;
    using BusinessObjects.Classes;
    using BusinessObjects.Queries.Interfaces;
    using Prescriptions.Test.Data;
    using Moq;
    using NUnit.Framework;

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
                QueryFactory.Setup(
                    f => f.CalcAvgCostByCodeByRegion(Data.BnfCode1, It.Is<Region>(m => m.Equals(r)), Practices))
                    .Returns(query.Object);
            }
            // Mock reader
            PrescriptionsReader.Setup(r => r.ExecuteQuery(It.IsAny<List<ICalcAvgCostByCodeByRegion>>()));
            // Instantiate service
            PrescriptionsService = new PrescriptionsService(Practices, PrescriptionsReader.Object, QueryFactory.Object);

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

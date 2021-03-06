﻿namespace GP.Prescriptions.BusinessLayer.Test.Services.PrescriptionsServiceTests
{
    using System.Collections.Generic;
    using BusinessLayer.Services.Core;
    using BusinessObjects.Classes;
    using BusinessObjects.Queries.Interfaces;
    using Moq;
    using NUnit.Framework;

    public class GetTotalSpendPerPostcodeTests : BasePrescriptionsServiceTests
    {
        private Mock<ICalcTotalActCostPerPostcode> query;

        private Dictionary<string, decimal> regionSpends;

        [SetUp]
        public void Setup()
        {
            BaseSetup();
            query = new Mock<ICalcTotalActCostPerPostcode>();
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
            QueryFactory.Setup(f => f.CalcTotalSpendPerPostcode(Practices)).Returns(query.Object);
            // Mock reader
            PrescriptionsReader.Setup(r => r.ExecuteQuery(query.Object));
            // Instantiate service
            PrescriptionsService = new PrescriptionsService(Practices, PrescriptionsReader.Object, QueryFactory.Object);

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

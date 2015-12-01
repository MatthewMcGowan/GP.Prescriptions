﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using NUnit.Framework;
    using Moq;
    using Core;
    using Prescriptions.Test.Data;
    using DataAccess.QueryTasks.Interfaces;

    public class GetAverageActCostTests : BasePrescriptionsServiceTests
    {
        private Mock<ICalcAvgCostByCode> query;

        [SetUp]
        public void Setup()
        {
            query = new Mock<ICalcAvgCostByCode>();
        }

        [Test]
        public void GetAverageActCost_ValidBnfCodeGiven_CorrectAverageCostCalculated()
        {
            // Mock query
            query.Setup(q => q.Result).Returns(5M);
            queryTaskFactory.Setup(f => f.CalcAvgCostByCode(Data.BnfCode1)).Returns(query.Object);
            // Mock reader
            prescriptionsReader.Setup(r => r.ExecuteQueryTask(query.Object));
            // Create instance of service
            prescriptionsService = new PrescriptionsService(GetPractices(), prescriptionsReader.Object, queryTaskFactory.Object);

            // Call service
            var result = prescriptionsService.GetAverageActCost(Data.BnfCode1);

            // Ensure result is as returned by query
            Assert.AreEqual(result, 5M);
            // Ensure query execution was called
            prescriptionsReader.VerifyAll();
        }
    }
}
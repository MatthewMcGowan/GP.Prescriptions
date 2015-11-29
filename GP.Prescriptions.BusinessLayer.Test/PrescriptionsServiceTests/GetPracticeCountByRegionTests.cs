using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using NUnit.Framework;
    using Moq;
    using Core;
    using BusinessObjects.Classes;

    [TestFixture]
    public class GetPracticeCountByRegionTests : BasePrescriptionsServiceTests
    {
        [SetUp]
        public void Setup()
        {
            MockDependencies();
        }


        [Test]
        public void GetPracticeCountByRegion_ValidRegionGiven_CorrectCountReturned()
        {
            prescriptionsService = new PrescriptionsService(practicesReader.Object, 
                postcodesReader.Object, prescriptionsReader.Object);

            int result = prescriptionsService.GetPracticeCountByRegion(Region.London);

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void GetPracticeCountByRegion_RegionHasNoPractices_ZeroReturned()
        {
            prescriptionsService = new PrescriptionsService(practicesReader.Object,
                postcodesReader.Object, prescriptionsReader.Object);

            int result = prescriptionsService.GetPracticeCountByRegion(Region.SouthEast);

            Assert.AreEqual(result, 0);
        }
    }
}

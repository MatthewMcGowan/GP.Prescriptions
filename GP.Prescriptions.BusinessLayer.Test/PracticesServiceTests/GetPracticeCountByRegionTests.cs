using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PracticesServiceTests
{
    using NUnit.Framework;
    using Moq;
    using Core;
    using BusinessObjects.Classes;

    [TestFixture]
    public class GetPracticeCountByRegionTests : BasePracticesServiceTests
    {
        [SetUp]
        public void Setup()
        {
            MockDependencies();
        }


        [Test]
        public void GetPracticeCountByRegion_ValidRegionGiven_CorrectCountReturned()
        {
            practicesService = new PracticesService(practicesReader.Object, postcodesReader.Object);

            int result = practicesService.GetPracticeCountByRegion(Region.London);

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void GetPracticeCountByRegion_RegionHasNoPractices_ZeroReturned()
        {
            practicesService = new PracticesService(practicesReader.Object, postcodesReader.Object);

            int result = practicesService.GetPracticeCountByRegion(Region.SouthEast);

            Assert.AreEqual(result, 0);
        }
    }
}

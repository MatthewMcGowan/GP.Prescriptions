namespace GP.Prescriptions.BusinessLayer.Test.Services.PracticesServiceTests
{
    using GP.Prescriptions.BusinessLayer.Services.Core;
    using GP.Prescriptions.BusinessObjects.Classes;

    using NUnit.Framework;

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

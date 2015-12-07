namespace GP.Prescriptions.BusinessLayer.Test.Services.PracticesServiceTests
{
    using BusinessLayer.Services.Core;
    using BusinessObjects.Classes;

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
            PracticesService = new PracticesService(PracticesReader.Object, PostcodesReader.Object);

            int result = PracticesService.GetPracticeCountByRegion(Region.London);

            Assert.AreEqual(result, 1);
        }

        [Test]
        public void GetPracticeCountByRegion_RegionHasNoPractices_ZeroReturned()
        {
            PracticesService = new PracticesService(PracticesReader.Object, PostcodesReader.Object);

            int result = PracticesService.GetPracticeCountByRegion(Region.SouthEast);

            Assert.AreEqual(result, 0);
        }
    }
}

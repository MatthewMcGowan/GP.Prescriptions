namespace GP.Prescriptions.BusinessLayer.Test.Services.PracticesServiceTests
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using BusinessLayer.Services.Core;
    using BusinessObjects.Structs;
    using DataAccess.Readers.Interfaces;
    using Prescriptions.Test.Data;
    using Moq;

    public abstract class BasePracticesServiceTests
    {
        #region Protected Fields

        protected readonly Mock<IPracticesCsvReader> PracticesReader;
        protected readonly Mock<IPostcodesCsvReader> PostcodesReader;

        protected PracticesService PracticesService;

        #endregion

        #region Constructors

        protected BasePracticesServiceTests()
        {
            PracticesReader = new Mock<IPracticesCsvReader>();
            PostcodesReader = new Mock<IPostcodesCsvReader>();
        }

        #endregion

        #region Protected Methods

        protected void MockDependencies()
        {
            PracticesReader.Setup(r => r.GetPracticeData()).Returns(GetPracticeList());
            PostcodesReader.Setup(r => r.GetPracticeDictionary(It.IsAny<List<PracticeData>>())).Returns(GetPractceDictionary());
        }

        protected List<PracticeData> GetPracticeList()
        {
            var practiceData1 = new PracticeData
            {
                PracticeCode = Data.PracticeCode1,
                Postcode = Data.Postcode1
            };

            var practiceData2 = new PracticeData
            {
                PracticeCode = Data.PracticeCode2,
                Postcode = Data.Postcode2
            };

            return new List<PracticeData> { practiceData1, practiceData2 };
        }

        protected ConcurrentDictionary<string, PostcodeRegion> GetPractceDictionary()
        {
            // Create test PostcodeRegions
            var postcodeRegion1 = new PostcodeRegion
            {
                Postcode = Data.Postcode1,
                Region = Data.RegionLondon
            };

            var postcodeRegion2 = new PostcodeRegion
            {
                Postcode = Data.Postcode2,
                Region = Data.RegionNe
            };

            // Create dictionary to return, add the values
            var dictionary = new ConcurrentDictionary<string, PostcodeRegion>();
            dictionary.TryAdd(Data.PracticeCode1, postcodeRegion1);
            dictionary.TryAdd(Data.PracticeCode2, postcodeRegion2);

            return dictionary;
        }

        #endregion
    }
}

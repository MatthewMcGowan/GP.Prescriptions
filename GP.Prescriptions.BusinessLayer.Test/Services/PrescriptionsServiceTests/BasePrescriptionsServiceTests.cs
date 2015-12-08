namespace GP.Prescriptions.BusinessLayer.Test.Services.PrescriptionsServiceTests
{
    using System.Collections.Concurrent;
    using BusinessLayer.Services.Core;
    using BusinessObjects.Classes;
    using BusinessObjects.Factories.Interfaces;
    using BusinessObjects.Structs;
    using DataAccess.Readers.Interfaces;
    using Prescriptions.Test.Data;
    using Moq;

    public abstract class BasePrescriptionsServiceTests
    {
        #region Protected Fields

        protected Mock<IPrescriptionsCsvReader> PrescriptionsReader;
        protected Mock<IPrescriptionsQueryFactory> QueryFactory;

        protected Practices Practices;
        protected PrescriptionsService PrescriptionsService;

        #endregion

        #region Constructors

        protected void BaseSetup()
        {
            PrescriptionsReader = new Mock<IPrescriptionsCsvReader>();
            QueryFactory = new Mock<IPrescriptionsQueryFactory>();
        }

        #endregion

        #region Protected Methods

        protected Practices GetPractices()
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

            // Create dictionary, add the values
            var dictionary = new ConcurrentDictionary<string, PostcodeRegion>();
            dictionary.TryAdd(Data.PracticeCode1, postcodeRegion1);
            dictionary.TryAdd(Data.PracticeCode2, postcodeRegion2);

            // Return new Practices object
            return new Practices(dictionary);
        }

        #endregion
    }
}

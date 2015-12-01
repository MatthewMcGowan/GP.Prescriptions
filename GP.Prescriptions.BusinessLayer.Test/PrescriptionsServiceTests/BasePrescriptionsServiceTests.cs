namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using Core;
    using DataAccess.Readers.Interfaces;
    using BusinessObjects.Structs;
    using Moq;
    using Prescriptions.Test.Data;
    using System.Collections.Concurrent;
    using BusinessObjects.Classes;
    using DataAccess.QueryTasks.Interfaces;

    public abstract class BasePrescriptionsServiceTests
    {
        #region Protected Fields

        protected Mock<IPrescriptionsCsvReader> PrescriptionsReader;
        protected Mock<IPrescriptionsQueryTaskFactory> QueryTaskFactory;

        protected Practices Practices;
        protected PrescriptionsService PrescriptionsService;

        #endregion

        #region Constructors

        protected void BaseSetup()
        {
            PrescriptionsReader = new Mock<IPrescriptionsCsvReader>();
            QueryTaskFactory = new Mock<IPrescriptionsQueryTaskFactory>();
        }

        #endregion

        #region Protected Methods

        protected Practices GetPractices()
        {
            // Create test PostcodeRegions
            var postcodeRegion1 = new PostcodeRegion
            {
                Postcode = Data.Postcode1,
                Region = Data.Region1
            };

            var postcodeRegion2 = new PostcodeRegion
            {
                Postcode = Data.Postcode2,
                Region = Data.Region2
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

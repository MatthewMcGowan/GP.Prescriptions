using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Test.PrescriptionsServiceTests
{
    using Core;
    using DataAccess.Readers.Interfaces;
    using BusinessObjects.Structs;
    using Moq;
    using GP.Prescriptions.Test.Data;
    using System.Collections.Concurrent;
    using BusinessObjects.Classes;
    using DataAccess.QueryTasks.Interfaces;

    public abstract class BasePrescriptionsServiceTests
    {
        #region Protected Fields

        protected Mock<IPrescriptionsCsvReader> prescriptionsReader;
        protected Mock<IPrescriptionsQueryTaskFactory> queryTaskFactory;

        protected PrescriptionsService prescriptionsService;

        #endregion

        #region Constructors

        public BasePrescriptionsServiceTests()
        {
            prescriptionsReader = new Mock<IPrescriptionsCsvReader>();
            queryTaskFactory = new Mock<IPrescriptionsQueryTaskFactory>();
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

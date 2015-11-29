﻿using System;
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

    public abstract class BasePrescriptionsServiceTests
    {
        #region Protected Fields

        protected readonly Mock<IPracticesCsvReader> practicesReader;
        protected readonly Mock<IPostcodesCsvReader> postcodesReader;
        protected readonly Mock<IPrescriptionsCsvReader> prescriptionsReader;

        protected PrescriptionsService prescriptionsService;

        #endregion

        #region Constructors

        public BasePrescriptionsServiceTests()
        {
            practicesReader = new Mock<IPracticesCsvReader>();
            postcodesReader = new Mock<IPostcodesCsvReader>();
            prescriptionsReader = new Mock<IPrescriptionsCsvReader>();
        }

        #endregion

        #region Protected Methods

        protected void MockDependencies()
        {
            practicesReader.Setup(r => r.GetPracticeData()).Returns(GetPracticeList());
            postcodesReader.Setup(r => r.GetPracticeDictionary(It.IsAny<List<PracticeData>>())).Returns(GetPractceDictionary());
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
                Region = Data.Region1
            };

            var postcodeRegion2 = new PostcodeRegion
            {
                Postcode = Data.Postcode2,
                Region = Data.Region2
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

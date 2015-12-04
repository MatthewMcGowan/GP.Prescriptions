namespace GP.Prescriptions.BusinessObjects.Test.Queries
{
    using System.Collections.Concurrent;

    using Classes;

    using GP.Prescriptions.BusinessObjects.Objects;

    using Structs;
    using Prescriptions.Test.Data;

    public abstract class BaseQueriesTests
    {
        #region Protected Fields

        protected Practices Practices;
        protected PrescriptionData ValidRow;
        protected PrescriptionData ValidRowDifferentCosts;
        protected PrescriptionData ZeroRow;
        protected PrescriptionData ValidRowBnfCode2;
        protected PrescriptionData ValidRowPractice2;

        #endregion

        protected BaseQueriesTests()
        {
            PopulatePractices();
            PopulateRowData();
        }

        protected void PopulatePractices()
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
            Practices = new Practices(dictionary);
        }

        public void PopulateRowData()
        {
            ValidRow = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.Items1,
                NIC = Data.Cost1,
                ActualCost = Data.Cost2,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            ValidRowDifferentCosts = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.Items2,
                NIC = Data.Cost2,
                ActualCost = Data.Cost3,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            ZeroRow = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode1,
                Items = Data.ItemsZero,
                NIC = Data.CostZero,
                ActualCost = Data.CostZero,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            ValidRowBnfCode2 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode1,
                BNFCode = Data.BnfCode2,
                Items = Data.Items1,
                NIC = Data.Cost1,
                ActualCost = Data.Cost1,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };

            ValidRowPractice2 = new PrescriptionData
            {
                PracticeCode = Data.PracticeCode2,
                BNFCode = Data.BnfCode1,
                Items = Data.Items1,
                NIC = Data.Cost1,
                ActualCost = Data.Cost2,

                SHA = string.Empty,
                PCT = string.Empty,
                BNFName = string.Empty,
                Period = string.Empty
            };
        }
    }
}
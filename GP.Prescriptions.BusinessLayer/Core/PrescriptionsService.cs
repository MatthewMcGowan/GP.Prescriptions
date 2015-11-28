using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Core
{
    using DataAccess.Readers.Core;
    using DataAccess.Readers.Interfaces;
    using BusinessObjects.Classes;
    using Interfaces;
    using DataAccess.QueryTasks.Core;
    using DataAccess.QueryTasks.Interfaces;

    public class PrescriptionsService : IPrescriptionsService
    {
        #region Private Fields

        private readonly IPracticesCsvReader practicesReader;
        private readonly IPostcodesCsvReader postcodesReader;
        private readonly IPrescriptionsCsvReader prescriptionsReader;

        private Practices practices;

        #endregion

        #region Constructors

        public PrescriptionsService(IPracticesCsvReader practicesReader, IPostcodesCsvReader postcodesReader,
            IPrescriptionsCsvReader prescriptionsReader)
        {
            // Set DataAccess objects
            this.practicesReader = practicesReader;
            this.postcodesReader = postcodesReader;
            this.prescriptionsReader = prescriptionsReader;

            // Read the practices & postcodes CSVs to obtain practice data
            var practicesData = practicesReader.GetPracticeData();
            var practicesDictionary = postcodesReader.GetPracticeDictionary(practicesData);

            // Set the practices data
            practices = new Practices(practicesDictionary);
        }

        public PrescriptionsService() : this (new PracticesCsvReader(), new PostcodesCsvReader(), new PrescriptionsCsvReader())
        {
        }

        #endregion

        #region Public Methods

        public void GetAllAnalysis()
        {

        }

        public int GetPracticeCountByRegion(Region region)
        {
            return practices.Dictionary.Count(p => p.Value.Region == region.ToString());
        }

        public decimal GetAverageActCost(string bnfCode)
        {
            // Create query
            var query = new CalculateAverageActCostByBnfCode(bnfCode);

            // Query csv reader
            prescriptionsReader.ExecuteQueryTask(query);

            // Return the result
            return query.Result;
        }

        public Dictionary<string, decimal> GetTotalSpendPerPostcode()
        {
            // Create query, passing the practices list
            var query = new CalculateTotalSpendPerPostcode(practices);

            // Query with csv
            prescriptionsReader.ExecuteQueryTask(query);

            // Return result
            return query.Result;
        }

        public decimal GetAverageActCostByRegion(string bnfCode, Region region)
        {
            var query = new CalculateAverageActCostByBnfCodeByRegion(bnfCode, region, practices);
            prescriptionsReader.ExecuteQueryTask(query);
            return query.Result;
        }

        public Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode)
        {
            // Create list
            var queries = new List<CalculateAverageActCostByBnfCodeByRegion>();

            // Create query for each region
            GetAllRegions().ForEach(r => queries.Add(
                new CalculateAverageActCostByBnfCodeByRegion(bnfCode, r, practices)));

            // Query csv file
            prescriptionsReader.ExecuteQueryTask(queries);

            // Return the results
            var retDictionary = new Dictionary<Region, decimal>();
            queries.ForEach(q => retDictionary.Add(q.Region, q.Result));
            return retDictionary;
        }

        #endregion

        #region Private Methods

        private List<Region> GetAllRegions()
        {
            return new List<Region>
            {
                Region.EastMidlands,
                Region.EastOfEngland,
                Region.London,
                Region.NorthEast,
                Region.NorthWest,
                Region.SouthEast,
                Region.SouthWest,
                Region.WestMidlands,
                Region.YorkshireAndTheHumber
            };
        }

        #endregion
    }
}

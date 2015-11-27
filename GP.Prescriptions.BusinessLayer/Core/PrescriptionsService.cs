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
    using DataAccess.QueryTasks.Interfaces;
    using DataAccess.QueryTasks.Core;

    public class PrescriptionsService : IPrescriptionsService
    {
        #region Private Fields

        private readonly IPracticesCsvReader practicesReader;
        private readonly IPostcodesCsvReader postcodesReader;

        private Practices practices;

        #endregion

        #region Constructors

        public PrescriptionsService(IPracticesCsvReader practicesReader, IPostcodesCsvReader postcodesReader)
        {
            // Set DataAccess objects
            this.practicesReader = practicesReader;
            this.postcodesReader = postcodesReader;

            // Read the practices & postcodes CSVs to obtain practice data
            var practicesData = practicesReader.GetPracticeData();
            var practicesDictionary = postcodesReader.GetPracticeDictionary(practicesData);

            // Set the practices data
            practices = new Practices(practicesDictionary);
        }

        public PrescriptionsService() : this (new PracticesCsvReader(), new PostcodesCsvReader())
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

        public decimal GetAverageActCostByBnfCode(string bnfCode)
        {
            // Create query
            var query = new CalculateAverageActCostByBnfCode(bnfCode);

            // Create csv reader
            var reader = new PrescriptionsCsvReader();

            // Query csv reader
            reader.ExecuteQueryTask(query);

            // Return the result
            return query.Result;
        }

        public Dictionary<string, decimal> GetTotalSpendPerPostcode()
        {
            throw new NotImplementedException();
        }

        public decimal GetAveragePrescriptionPriceByBnfCode(string bnfCode)
        {
            throw new NotImplementedException();
        }

        public Dictionary<Region, decimal> GetAveragePrescriptionPricePerRegionByBnfCode(string bnfCode)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}

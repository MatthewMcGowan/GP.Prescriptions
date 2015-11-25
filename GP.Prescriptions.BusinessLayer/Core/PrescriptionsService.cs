using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Core
{
    using DataAccess.Core;
    using DataAccess.Interfaces;
    using BusinessObjects.Classes;
    using Interfaces;

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
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Core
{
    using BusinessObjects.Classes;
    using DataAccess.Readers.Core;
    using DataAccess.Readers.Interfaces;
    using Interfaces;

    public class PracticesService : IPracticesService
    {
        #region Private Fields

        private readonly IPracticesCsvReader practicesReader;
        private readonly IPostcodesCsvReader postcodesReader;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="PracticesService"/> class.
        /// </summary>
        /// <param name="practicesReader">The practices reader.</param>
        /// <param name="postcodesReader">The postcodes reader.</param>
        public PracticesService(IPracticesCsvReader practicesReader, IPostcodesCsvReader postcodesReader)
        {
            this.practicesReader = practicesReader;
            this.postcodesReader = postcodesReader;

            InitialisePractices();
        }

        public PracticesService()
            : this(new PracticesCsvReader(), new PostcodesCsvReader())
        {
        }

        #endregion

        #region Public Properties

        public Practices Practices { get; private set; }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the practice count by region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns></returns>
        public int GetPracticeCountByRegion(Region region)
        {
            return Practices.Dictionary.Count(p => p.Value.Region == region.ToString());
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Gets all practices, along with their regions.
        /// </summary>
        private void InitialisePractices()
        {
            // Use the practices reader to obtain practice data
            var practicesData = this.practicesReader.GetPracticeData();

            // Get the regions for these practices (and validate the postcode exists)
            var practicesDictionary = this.postcodesReader.GetPracticeDictionary(practicesData);

            // Return practices object
            Practices = new Practices(practicesDictionary);
        }

        #endregion
    }
}

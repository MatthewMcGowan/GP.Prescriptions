using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Core
{
    using System.Runtime.CompilerServices;

    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.DataAccess.Readers.Core;
    using GP.Prescriptions.DataAccess.Readers.Interfaces;

    public class PracticesService
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
        }

        public PracticesService()
            : this(new PracticesCsvReader(), new PostcodesCsvReader())
        {
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets all practices, along with their regions.
        /// </summary>
        /// <returns>Practices object.</returns>
        public Practices GetAllPractices()
        {
            // Use the practices reader to obtain practice data
            var practicesData = this.practicesReader.GetPracticeData();

            // Get the regions for these practices (and validate the postcode exists)
            var practicesDictionary = this.postcodesReader.GetPracticeDictionary(practicesData);

            // Return practices object
            return new Practices(practicesDictionary);
        }

        #endregion
    }
}

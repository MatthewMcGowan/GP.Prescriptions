namespace GP.Prescriptions.BusinessObjects.Classes
{
    using System.Collections.Concurrent;

    using Structs;

    /// <summary>
    /// An object containing all practice data.
    /// </summary>
    public class Practices
    {
        #region Private Fields

        /// <summary>
        /// The dictionary of practices.
        /// </summary>
        private readonly ConcurrentDictionary<string, PostcodeRegion> dictionary;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="Practices"/> class.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        public Practices(ConcurrentDictionary<string, PostcodeRegion> dictionary)
        {
            this.dictionary = dictionary;
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the dictionary.
        /// </summary>
        /// <value>
        /// The dictionary of practices.
        /// </value>
        public ConcurrentDictionary<string, PostcodeRegion> Dictionary
        {
            get
            {
                return dictionary;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Gets the practices oostcode by PracticeCode.
        /// </summary>
        /// <param name="practiceCode">The practice code.</param>
        /// <returns></returns>
        public string GetPracticePostcodeByPracticeCode(string practiceCode)
        {
            PostcodeRegion data;

            return dictionary.TryGetValue(practiceCode, out data) ? data.Postcode : null;
        }

        /// <summary>
        /// Gets the practice region by PracticeCode.
        /// </summary>
        /// <param name="practiceCode">The practice code.</param>
        /// <returns></returns>
        public string GetPracticeRegionByPracticeCode(string practiceCode)
        {
            PostcodeRegion data;

            return dictionary.TryGetValue(practiceCode, out data) ? data.Region : null;
        }

        #endregion
    }
}

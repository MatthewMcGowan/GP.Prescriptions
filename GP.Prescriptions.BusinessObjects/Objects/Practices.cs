using GP.Prescriptions.BusinessObjects.Structs;

using System.Collections.Concurrent;

namespace GP.Prescriptions.BusinessObjects.Classes
{
    public class Practices
    {
        #region Private Fields

        private readonly ConcurrentDictionary<string, PostcodeRegion> dictionary;

        #endregion

        #region Constructors

        public Practices(ConcurrentDictionary<string, PostcodeRegion> dictionary)
        {
            this.dictionary = dictionary;
        }

        #endregion

        #region Public Properties

        public ConcurrentDictionary<string, PostcodeRegion> Dictionary
        {
            get
            {
                return dictionary;
            }
        }

        #endregion

        #region Public Methods

        public string GetPracticePostcodeByPracticeCode(string practiceCode)
        {
            PostcodeRegion data;

            return dictionary.TryGetValue(practiceCode, out data) ? data.Postcode : null;
        }

        public string GetPracticeRegionByPracticeCode(string practiceCode)
        {
            PostcodeRegion data;

            return dictionary.TryGetValue(practiceCode, out data) ? data.Region : null;
        }

        #endregion
    }
}

using GP.Prescriptions.BusinessObjects.Structs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public string GetPracticeRegionByPracticeCode(string practiceCode)
        {
            PostcodeRegion data;

            return dictionary.TryGetValue(practiceCode, out data) ? data.Region : string.Empty;
        }

        #endregion
    }
}

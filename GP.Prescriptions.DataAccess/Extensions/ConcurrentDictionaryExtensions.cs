using GP.Prescriptions.BusinessObjects.Structs;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.Extensions
{
    public static class ConcurrentDictionaryExtensions
    {
        public static void TryAdd(this ConcurrentDictionary<string, PostcodeRegion> dictionary, 
            PracticeData practicedata, string region)
        {
            dictionary.TryAdd(practicedata.PracticeCode, new PostcodeRegion
            {
                Postcode = practicedata.Postcode,
                Region = region
            });
        }
    }
}

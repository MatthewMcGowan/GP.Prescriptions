namespace GP.Prescriptions.BusinessObjects.Extensions
{
    using System.Collections.Concurrent;

    using Structs;

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

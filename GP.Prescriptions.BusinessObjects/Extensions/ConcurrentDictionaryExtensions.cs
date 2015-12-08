namespace GP.Prescriptions.BusinessObjects.Extensions
{
    using System.Collections.Concurrent;
    using Structs;

    /// <summary>
    /// Extensions for ConcurrentDictionary object.
    /// </summary>
    public static class ConcurrentDictionaryExtensions
    {
        /// <summary>
        /// Tries to add a postcode region.
        /// </summary>
        /// <param name="dictionary">The dictionary.</param>
        /// <param name="practicedata">The practice data.</param>
        /// <param name="region">The region.</param>
        public static void TryAdd(
            this ConcurrentDictionary<string, PostcodeRegion> dictionary,
            PracticeData practicedata,
            string region)
        {
            dictionary.TryAdd(
                practicedata.PracticeCode,
                new PostcodeRegion { Postcode = practicedata.Postcode, Region = region });
        }
    }
}

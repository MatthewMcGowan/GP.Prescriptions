namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using BusinessObjects.Structs;

    /// <summary>
    /// Interface for PostcodesCsvReader.
    /// </summary>
    public interface IPostcodesCsvReader
    {
        /// <summary>
        /// Gets the practice dictionary.
        /// </summary>
        /// <param name="practicesData">The practices data.</param>
        /// <returns></returns>
        ConcurrentDictionary<string, PostcodeRegion> GetPracticeDictionary(List<PracticeData> practicesData);
    }
}

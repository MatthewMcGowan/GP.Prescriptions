namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    using BusinessObjects.Structs;

    public interface IPostcodesCsvReader
    {
        ConcurrentDictionary<string, PostcodeRegion> GetPracticeDictionary(List<PracticeData> practicesData);
    }
}

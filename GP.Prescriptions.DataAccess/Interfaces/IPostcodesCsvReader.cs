using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.Interfaces
{
    using BusinessObjects.Structs;

    public interface IPostcodesCsvReader
    {
        ConcurrentDictionary<string, PostcodeRegion> GetPracticeDictionary(List<PracticeData> practicesData);
    }
}

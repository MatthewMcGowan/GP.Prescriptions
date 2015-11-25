using GP.Prescriptions.BusinessObjects.Structs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    public interface IPracticesCsvReader
    {
        List<PracticeData> GetPracticeData();
    }
}

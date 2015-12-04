namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Generic;

    using BusinessObjects.Structs;
    
    public interface IPracticesCsvReader
    {
        List<PracticeData> GetPracticeData();
    }
}

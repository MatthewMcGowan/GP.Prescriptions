namespace GP.Prescriptions.DataAccess.Readers.Interfaces
{
    using System.Collections.Generic;

    using BusinessObjects.Structs;

    /// <summary>
    /// Interface for PracticesCsvReader.
    /// </summary>
    public interface IPracticesCsvReader
    {
        /// <summary>
        /// Gets the practice data.
        /// </summary>
        /// <returns></returns>
        List<PracticeData> GetPracticeData();
    }
}

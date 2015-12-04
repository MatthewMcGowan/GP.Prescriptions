namespace GP.Prescriptions.DataAccess.Readers.Core
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using BusinessObjects.Structs;
    using LumenWorks.Framework.IO.Csv;
    using System.IO;
    using Interfaces;

    public class PracticesCsvReader : IPracticesCsvReader
    {
        #region Private Fields

        private readonly string practiceCsvFile = ConfigurationManager.AppSettings.Get("PracticesCsv");
        private readonly bool fileHasHeaders = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PracticesCsvHasHeaders"));

        #endregion

        #region Public Methods

        public List<PracticeData> GetPracticeData()
        {
            var practicesData = new List<PracticeData>();

            using (var csv = new CsvReader(new StreamReader(practiceCsvFile), fileHasHeaders))
            {
                while (csv.ReadNextRecord())
                {
                    practicesData.Add(new PracticeData
                    {
                        PracticeCode = csv[1],
                        Postcode = csv[7]
                    });
                }
            }

            return practicesData;
        }

        #endregion
    }
}

namespace GP.Prescriptions.DataAccess.Readers.Core
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;

    using LumenWorks.Framework.IO.Csv;
    using Interfaces;
    using System.IO;
    using Extensions;
    using BusinessObjects.Extensions;

    using BusinessObjects.Queries.Interfaces;

    public class PrescriptionsCsvReader : IPrescriptionsCsvReader
    {
        #region Private Fields

        private readonly string prescriptionsCsvFile = ConfigurationManager.AppSettings.Get("PrescriptionsCsv");
        private readonly bool fileHasHeaders = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PrescriptionsCsvHasHeaders"));

        #endregion

        #region Public Methods

        public void ExecuteQuery(IPrescriptionsQuery query)
        {
            using (var csv = new CsvReader(new StreamReader(prescriptionsCsvFile), fileHasHeaders))
            {
                // Read all the rows
                while (csv.ReadNextRecord())
                {
                    // Get data from row
                    var row = csv.PrescriptionCsvRowToStruct();

                    // Process the data for this query
                    query.ProcessRow(row);
                }
            }
        }

        public void ExecuteQuery(IEnumerable<IPrescriptionsQuery> queries)
        {
            using (var csv = new CsvReader(new StreamReader(prescriptionsCsvFile), fileHasHeaders))
            {
                // Read all the rows
                while (csv.ReadNextRecord())
                {
                    // Get data from row
                    var row = csv.PrescriptionCsvRowToStruct();

                    // Process this data for each query
                    queries.ForEach(q => q.ProcessRow(row));
                }
            }  
        }

        #endregion
    }
}

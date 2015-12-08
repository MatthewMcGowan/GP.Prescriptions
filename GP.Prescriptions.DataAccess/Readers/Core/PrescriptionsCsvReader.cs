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
    using BusinessObjects.Classes;

    /// <summary>
    /// Reads the prescriptions CSV, performing a given query.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.DataAccess.Readers.Interfaces.IPrescriptionsCsvReader" />
    public class PrescriptionsCsvReader : IPrescriptionsCsvReader
    {
        #region Private Fields

        /// <summary>
        /// The prescriptions CSV file.
        /// </summary>
        private readonly string prescriptionsCsvFile = ConfigurationManager.AppSettings.Get("PrescriptionsCsv");

        /// <summary>
        /// Whether the file has headers.
        /// </summary>
        private readonly bool fileHasHeaders = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PrescriptionsCsvHasHeaders"));

        #endregion

        #region Public Methods

        /// <summary>
        /// Executes the query.
        /// </summary>
        /// <param name="query">The query.</param>
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

        /// <summary>
        /// Executes the queries.
        /// </summary>
        /// <param name="queries">The queries.</param>
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

        /// <summary>
        /// Executes the queries.
        /// </summary>
        /// <param name="batch">The batch.</param>
        public void ExecuteQuery(PrescriptionsQueryBatch batch)
        {
            ExecuteQuery(batch.Queries);
        }

        #endregion
    }
}

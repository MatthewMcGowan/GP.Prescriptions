﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GP.Prescriptions.DataAccess.Readers.Core
{
    using LumenWorks.Framework.IO.Csv;
    using QueryTasks.Interfaces;
    using Readers.Interfaces;
    using System.IO;
    using Extensions;
    using BusinessObjects.Extensions;

    public class PrescriptionsCsvReader : IPrescriptionsCsvReader
    {
        #region Private Fields

        private readonly string prescriptionsCsvFile = ConfigurationManager.AppSettings.Get("PrescriptionsCsv");
        private readonly bool fileHasHeaders = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PrescriptionsCsvHasHeaders"));

        #endregion

        #region Public Methods

        public void ExecuteQueryTask(IPrescriptionsQueryTask query)
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

        public void ExecuteQueryTask(IEnumerable<IPrescriptionsQueryTask> queries)
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

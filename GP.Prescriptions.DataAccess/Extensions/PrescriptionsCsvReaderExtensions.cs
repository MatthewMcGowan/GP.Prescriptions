namespace GP.Prescriptions.DataAccess.Extensions
{
    using BusinessObjects.Structs;
    using LumenWorks.Framework.IO.Csv;

    /// <summary>
    /// Extensions for PrescriptionsCsvReader.
    /// </summary>
    public static class PrescriptionsCsvReaderExtensions
    {
        /// <summary>
        /// Turns a row from prescriptions CSV into a PrescriptionData struct.
        /// </summary>
        /// <param name="row">The row.</param>
        /// <returns>PrescriptionData struct.</returns>
        public static PrescriptionData PrescriptionCsvRowToStruct(this CsvReader row)
        {
            return new PrescriptionData
            {
                SHA = row[0],
                PCT = row[1],
                PracticeCode = row[2],
                BNFCode = row[3],
                BNFName = row[4],
                Items = int.Parse(row[5]),
                ActualCost = decimal.Parse(row[6]),
                NIC = decimal.Parse(row[7]),
                Period = row[8]
            };
        }
    }
}

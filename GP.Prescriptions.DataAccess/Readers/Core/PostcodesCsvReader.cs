namespace GP.Prescriptions.DataAccess.Readers.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Configuration;
    using System.Collections.Concurrent;
    using System.IO;

    using BusinessObjects.Structs;
    using Interfaces;
    using LumenWorks.Framework.IO.Csv;
    using BusinessObjects.Extensions;

    public class PostcodesCsvReader : IPostcodesCsvReader
    {
        #region Private Fields

        private readonly string postcodesCsvFile = ConfigurationManager.AppSettings.Get("PostcodesCsv");
        private readonly bool fileHasHeaders = Convert.ToBoolean(ConfigurationManager.AppSettings.Get("PostcodesCsvHasHeaders"));

        #endregion

        #region Public Methods

        public ConcurrentDictionary<string, PostcodeRegion> GetPracticeDictionary(List<PracticeData> practicesData)
        {            
            // Sort list by post code
            // We want this in the same order as the postcodes file
            practicesData = practicesData.OrderBy(p => p.Postcode).ToList();

            // New concurrent dictionary to be returned
            var practiceDictionary = new ConcurrentDictionary<string, PostcodeRegion>();

            // Begin with the first practice
            int practiceIndex = 0;

            // Read the postcodes file sequentially (in order of postcodes)
            using (var csv = new CsvReader(new StreamReader(postcodesCsvFile), fileHasHeaders))
            {
                while (csv.ReadNextRecord())
                {
                    // Finish if all practices read
                    if (practiceIndex > (practicesData.Count() - 1))
                    {
                        break;
                    }

                    // Compare the current practice's postcode against the current row's postcode
                    int relativePosition = practicesData[practiceIndex].Postcode.CompareTo(csv[0].Trim());

                    // If postcodes are matched, then grab the region and add to dictionary
                    if (relativePosition == 0)
                    {
                        // Add all practices with this postcode to dictionary
                        while (practicesData[practiceIndex].Postcode == csv[0].Trim())
                        {
                            practiceDictionary.TryAdd(practicesData[practiceIndex], csv[24]);
                            practiceIndex++;
                            if (practiceIndex > practicesData.Count() - 1)
                            {
                                break;
                            }
                        }
                        continue;
                    }
                    // If value has been moved past without being found it's not present in postcode file.
                    // This indicates an invalid postcode, and is treated as null.
                    if (relativePosition < 0)
                    {
                        do
                        {
                            // TODO: Log
                            if (practiceIndex > practicesData.Count() - 1)
                            {
                                break;
                            }
                            practiceIndex++;
                        } while (practicesData[practiceIndex].Postcode.CompareTo(csv[0].Trim()) < 1);

                        // After skipping practice(s), the practice reached now could be the correct one for this postcode
                        while (practiceIndex < practicesData.Count() && practicesData[practiceIndex].Postcode == csv[0].Trim())
                        {
                            practiceDictionary.TryAdd(practicesData[practiceIndex++], csv[24]);

                            if (practiceIndex > practicesData.Count() - 1)
                            {
                                break;
                            }
                        }
                        continue;
                    }
                }
            }

            return practiceDictionary;
        }

        #endregion
    }
}

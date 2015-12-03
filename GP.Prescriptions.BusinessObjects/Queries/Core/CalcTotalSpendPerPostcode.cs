namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using System.Collections.Generic;

    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.BusinessObjects.Structs;

    using ICalcTotalSpendPerPostcode = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcTotalSpendPerPostcode;

    public class CalcTotalSpendPerPostcode : Interfaces.ICalcTotalSpendPerPostcode
    {
        #region Private Fields

        private readonly Practices practices;

        private Dictionary<string, decimal> postcodeSpends;

        #endregion

        #region Constructors

        public CalcTotalSpendPerPostcode(Practices practices)
        {
            // Set the practices
            this.practices = practices;

            // Create new dictionary of postcodes with corresponding total spend
            postcodeSpends = new Dictionary<string, decimal>();
        }

        #endregion

        #region Public Properties
        
        public Dictionary<string, decimal> Result
        {
            get
            {
                return postcodeSpends;
            }
        }

        #endregion

        #region Public Methods

        public void ProcessRow(PrescriptionData row)
        {
            string postcode = practices.GetPracticePostcodeByPracticeCode(row.PracticeCode);

            if (string.IsNullOrWhiteSpace(postcode))
            {
                //TODO: Log
                return;
            }

            // If postode does not exist in dictionary, add it
            if (!postcodeSpends.ContainsKey(postcode))
            {
                postcodeSpends.Add(postcode, row.ActualCost);
            }
            // Otherwise get it, and increase it's spend amount
            else
            {
                postcodeSpends[postcode] += row.ActualCost;
            }
        }

        #endregion
    }
}

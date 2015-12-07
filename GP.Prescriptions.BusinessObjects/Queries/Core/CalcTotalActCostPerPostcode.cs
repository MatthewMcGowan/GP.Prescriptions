namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using System.Collections.Generic;

    using Classes;
    using Structs;
    using Interfaces;

    /// <summary>
    /// Query calculating the total spend for all postcodes.
    /// </summary>
    /// <seealso cref="GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcTotalActCostPerPostcode" />
    public class CalcTotalActCostPerPostcode : ICalcTotalActCostPerPostcode
    {
        #region Private Fields

        /// <summary>
        /// The practices.
        /// </summary>
        private readonly Practices practices;

        /// <summary>
        /// The postcode spends.
        /// </summary>
        private readonly Dictionary<string, decimal> postcodeSpends;

        #endregion

        #region Constructors

        /// <summary>
        /// Initialises a new instance of the <see cref="CalcTotalActCostPerPostcode"/> class.
        /// </summary>
        /// <param name="practices">The practices.</param>
        public CalcTotalActCostPerPostcode(Practices practices)
        {
            // Set the practices
            this.practices = practices;

            // Create new dictionary of postcodes with corresponding total spend
            postcodeSpends = new Dictionary<string, decimal>();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the result.
        /// </summary>
        /// <value>
        /// The result.
        /// </value>
        public Dictionary<string, decimal> Result
        {
            get
            {
                return postcodeSpends;
            }
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Processes the row.
        /// </summary>
        /// <param name="row">The row.</param>
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

namespace GP.Prescriptions.BusinessObjects.Structs
{
    /// <summary>
    /// Data for a prescription.
    /// </summary>
    public struct PrescriptionData
    {
        /// <summary>
        /// Strategic Healthy Authority.
        /// </summary>
        public string SHA;

        /// <summary>
        /// The Primary Care Trust.
        /// </summary>
        public string PCT;

        /// <summary>
        /// The practice code.
        /// </summary>
        public string PracticeCode;

        /// <summary>
        /// The British National Formulary code.
        /// </summary>
        public string BNFCode;

        /// <summary>
        /// The BNF name.
        /// </summary>
        public string BNFName;

        /// <summary>
        /// The number of items sold.
        /// </summary>
        public int Items;

        /// <summary>
        /// Net Ingredient Cost.
        /// Basic price of a drug.
        /// </summary>
        public decimal NIC;

        /// <summary>
        /// The actual cost.
        /// "Prior to July 2012 this Actual Cost was defined as the Net Ingredient Cost
        /// less the average discount percentage received by pharmacists calculated from 
        /// the previous month , plus container allowance. This is the estimated cost to 
        /// the NHS, which is lower than NIC."
        /// </summary>
        public decimal ActualCost;

        /// <summary>
        /// The period.
        /// </summary>
        public string Period;
    }
}

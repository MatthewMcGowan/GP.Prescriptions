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

        public int Items;
        // Net Ingredient Cost.
        public decimal NIC;

        /// <summary>
        /// The actual cost.
        /// </summary>
        public decimal ActualCost;

        /// <summary>
        /// The period.
        /// </summary>
        public string Period;
    }
}

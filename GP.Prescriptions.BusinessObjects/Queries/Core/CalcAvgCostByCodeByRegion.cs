namespace GP.Prescriptions.BusinessObjects.Queries.Core
{
    using GP.Prescriptions.BusinessObjects.Classes;
    using GP.Prescriptions.BusinessObjects.Structs;

    using ICalcAvgCostByCodeByRegion = GP.Prescriptions.BusinessObjects.Queries.Interfaces.ICalcAvgCostByCodeByRegion;

    public class CalcAvgCostByCodeByRegion : BaseCalcAvgCostByCode, Interfaces.ICalcAvgCostByCodeByRegion
    {
        #region Private Fields

        private readonly Practices practices;

        #endregion

        #region Constructors

        public CalcAvgCostByCodeByRegion(string bnfCode, Region region, Practices practices) : base(bnfCode)
        {
            Region = region;
            this.practices = practices;
        }

        #endregion

        #region Public Properties

        public Region Region { get; private set; }

        #endregion

        #region Public Methods

        public override void ProcessRow(PrescriptionData row)
        {
            // Get region from practices
            string rowRegion = practices.GetPracticeRegionByPracticeCode(row.PracticeCode);

            // If row matches search criteria, add it
            if (row.BNFCode == bnfCode && rowRegion == Region.ToString())
            {
                totalSold += row.Items;
                totalCost += row.NIC;
            }
        }

        #endregion
    }
}

namespace GP.Prescriptions.BusinessLayer.Services.Interfaces
{
    using System.Collections.Generic;

    using GP.Prescriptions.BusinessObjects.Classes;

    public interface IPrescriptionsService
    {
        void GetAllAnalysis();

        decimal GetAverageActCost(string bnfCode);

        Dictionary<string, decimal> GetTotalSpendPerPostcode();

        Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode);
    }
}

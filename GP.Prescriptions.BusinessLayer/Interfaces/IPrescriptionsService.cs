using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface IPrescriptionsService
    {
        void GetAllAnalysis();

        int GetPracticeCountByRegion(Region region);

        decimal GetAverageActCost(string bnfCode);

        Dictionary<string, decimal> GetTotalSpendPerPostcode();

        Dictionary<Region, decimal> GetAverageActCostPerRegion(string bnfCode);
    }
}

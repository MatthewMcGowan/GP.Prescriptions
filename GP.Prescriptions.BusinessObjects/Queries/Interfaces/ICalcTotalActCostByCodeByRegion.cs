using GP.Prescriptions.BusinessObjects.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    public interface ICalcTotalActCostByCodeByRegion : IPrescriptionsQuery
    {
        string BnfCode { get; }

        Region Region { get; }

        decimal Result { get; }
    }
}

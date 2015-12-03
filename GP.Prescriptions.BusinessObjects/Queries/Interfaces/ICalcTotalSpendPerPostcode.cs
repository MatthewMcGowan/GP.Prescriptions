namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using System.Collections.Generic;

    public interface ICalcTotalSpendPerPostcode : IPrescriptionsQuery
    {
        Dictionary<string, decimal> Result { get; }
    }
}

namespace GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces
{
    using System.Collections.Generic;

    public interface ICalcTotalSpendPerPostcode : IPrescriptionsQueryTask
    {
        Dictionary<string, decimal> Result { get; }
    }
}

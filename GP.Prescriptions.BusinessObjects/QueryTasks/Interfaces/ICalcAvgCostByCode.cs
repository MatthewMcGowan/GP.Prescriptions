namespace GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces
{
    public interface ICalcAvgCostByCode : IPrescriptionsQueryTask
    {
        decimal Result { get; }
    }
}

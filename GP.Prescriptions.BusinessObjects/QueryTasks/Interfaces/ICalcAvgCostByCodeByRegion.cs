namespace GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface ICalcAvgCostByCodeByRegion : IPrescriptionsQueryTask
    {
        decimal Result { get; }

        Region Region { get; }
    }
}

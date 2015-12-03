namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    public interface ICalcAvgCostByCode : IPrescriptionsQuery
    {
        decimal Result { get; }
    }
}

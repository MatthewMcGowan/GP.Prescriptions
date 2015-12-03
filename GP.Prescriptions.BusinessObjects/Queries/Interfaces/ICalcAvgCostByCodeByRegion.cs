namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface ICalcAvgCostByCodeByRegion : IPrescriptionsQuery
    {
        decimal Result { get; }

        Region Region { get; }
    }
}

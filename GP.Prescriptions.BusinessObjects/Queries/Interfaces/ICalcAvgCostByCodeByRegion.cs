namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Classes;

    public interface ICalcAvgCostByCodeByRegion : IPrescriptionsQuery
    {
        decimal Result { get; }

        Region Region { get; }
    }
}

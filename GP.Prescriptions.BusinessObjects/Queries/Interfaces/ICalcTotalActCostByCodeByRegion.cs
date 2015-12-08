namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Classes;

    public interface ICalcTotalActCostByCodeByRegion : IPrescriptionsQuery
    {
        string BnfCode { get; }

        Region Region { get; }

        decimal Result { get; }
    }
}

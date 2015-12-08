namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Classes;

    public interface ICalcTotalNicByCodeByRegion : IPrescriptionsQuery
    {
        string BnfCode { get; }

        Region Region { get; }

        decimal Result { get; }
    }
}

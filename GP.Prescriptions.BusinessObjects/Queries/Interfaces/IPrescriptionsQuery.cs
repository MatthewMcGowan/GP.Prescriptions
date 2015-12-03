namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Structs;

    public interface IPrescriptionsQuery
    {
        void ProcessRow(PrescriptionData row);
    }
}

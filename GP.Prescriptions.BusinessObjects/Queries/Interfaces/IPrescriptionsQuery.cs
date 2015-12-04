namespace GP.Prescriptions.BusinessObjects.Queries.Interfaces
{
    using Structs;

    public interface IPrescriptionsQuery
    {
        void ProcessRow(PrescriptionData row);
    }
}

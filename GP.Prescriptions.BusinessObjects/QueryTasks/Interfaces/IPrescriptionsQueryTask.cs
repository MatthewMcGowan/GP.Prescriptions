namespace GP.Prescriptions.BusinessObjects.QueryTasks.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Structs;

    public interface IPrescriptionsQueryTask
    {
        void ProcessRow(PrescriptionData row);
    }
}

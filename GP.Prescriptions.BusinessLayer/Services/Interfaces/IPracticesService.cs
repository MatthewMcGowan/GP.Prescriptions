namespace GP.Prescriptions.BusinessLayer.Services.Interfaces
{
    using GP.Prescriptions.BusinessObjects.Classes;

    public interface IPracticesService
    {
        int GetPracticeCountByRegion(Region region);
    }
}

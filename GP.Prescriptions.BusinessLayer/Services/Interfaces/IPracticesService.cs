namespace GP.Prescriptions.BusinessLayer.Services.Interfaces
{
    using BusinessObjects.Classes;

    public interface IPracticesService
    {
        int GetPracticeCountByRegion(Region region);
    }
}

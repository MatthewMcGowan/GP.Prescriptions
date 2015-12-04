namespace GP.Prescriptions.BusinessLayer.Services.Interfaces
{
    using BusinessObjects.Classes;

    /// <summary>
    /// Interface for practices business service.
    /// </summary>
    public interface IPracticesService
    {
        /// <summary>
        /// Gets the practice count by region.
        /// </summary>
        /// <param name="region">The region.</param>
        /// <returns>The count.</returns>
        int GetPracticeCountByRegion(Region region);
    }
}

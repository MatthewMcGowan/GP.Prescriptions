using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.BusinessLayer.Interfaces
{
    using BusinessObjects.Classes;

    public interface IPracticesService
    {
        int GetPracticeCountByRegion(Region region);
    }
}

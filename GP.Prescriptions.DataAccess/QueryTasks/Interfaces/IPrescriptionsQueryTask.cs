﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.DataAccess.QueryTasks.Interfaces
{
    using BusinessObjects.Structs;

    public interface IPrescriptionsQueryTask
    {
        void ProcessRow(PrescriptionData row);
    }
}

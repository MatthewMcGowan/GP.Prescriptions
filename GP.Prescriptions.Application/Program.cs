using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GP.Prescriptions.Application
{
    using BusinessLayer.Core;
    using BusinessObjects.Classes;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performing startup...");

            var prescriptionService = new PrescriptionsService();

            Console.WriteLine("Startup completed.");
            Console.WriteLine("How many practices are in London?");
            Console.WriteLine("Processing...");

            int practicesInLondon = prescriptionService.GetPracticeCountByRegion(Region.London);
            Console.WriteLine(practicesInLondon);

            Console.WriteLine("What was the average actual cost of all peppermint oil prescriptions?");

        }
    }
}

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
            // Create prescription service instance
            Console.WriteLine("Performing startup...");
            var prescriptionService = new PrescriptionsService();
            Console.WriteLine("Startup completed.");

            // Find out how many practices there are in London
            Console.WriteLine("How many practices are in London?");
            Console.WriteLine("Processing...");
            int practicesInLondon = prescriptionService.GetPracticeCountByRegion(Region.London);
            Console.WriteLine(practicesInLondon);

            // Find out the average national cost of a peppermint oil prescription
            Console.WriteLine("What was the average actual cost of all peppermint oil prescriptions?");
            Console.WriteLine("Processing...");
            decimal averagePepermintOilCost = prescriptionService.GetAverageActCostByBnfCode("0102000T0");
            Console.WriteLine("£" + averagePepermintOilCost.ToString("#.##"));

            Console.ReadLine();
        }
    }
}

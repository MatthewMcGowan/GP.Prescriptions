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

            //decimal result = prescriptionService.GetAverageActCostByRegion("0501012G0", Region.London);
            //Console.WriteLine(result);


            if(askBooleanQuestion("Process all at once?"))
            {
                processOnce(prescriptionService);
            }
            else
            {
                process(prescriptionService);
            }

            Console.ReadLine();
        }

        private static bool askBooleanQuestion(string question)
        {
            // Ask user the question
            Console.WriteLine(question + " [y/n]");

            // Read their response
            char response = Console.ReadKey().KeyChar;
            Console.WriteLine();

            // If not correct input, ask again
            if (response != 'y' && response != 'n')
            {
                Console.WriteLine("Incorrect input");
                askBooleanQuestion(question);
            }

            // Return true/false based on user input
            if (response == 'y')
            {
                return true;
            }

            return false;
        }

        private static void process(PrescriptionsService prescriptionService)
        {
            // Find out how many practices there are in London
            Console.WriteLine("How many practices are in London?");
            int practicesInLondon = prescriptionService.GetPracticeCountByRegion(Region.London);
            Console.WriteLine(practicesInLondon);

            // Find out the average national cost of a peppermint oil prescription
            Console.WriteLine("What was the average actual cost of all peppermint oil prescriptions?");
            decimal averagePepermintOilCost = prescriptionService.GetAverageActCost("0102000T0");
            Console.WriteLine("£" + averagePepermintOilCost.ToString("#.##"));

            // Find the 5 highest spending postcodes
            Console.WriteLine("Which 5 post codes have the highest actual spend, and how much did each spend in total?");
            // Get postcode spends
            var totalPostcodeSpends = prescriptionService.GetTotalSpendPerPostcode();
            // Get top 5
            var topFive = totalPostcodeSpends.OrderByDescending(p => p.Value).Take(5).ToList();
            // Write to console
            topFive.ForEach(p => Console.WriteLine(p.Key + ": £" + p.Value));

            // Find average price of Flucloxacillin
            Console.WriteLine("For each region, what was the average price per prescription of Flucloxacillin,"
                + " and how did this vary from the national mean?");
            // Get average cost per region
            var averageFlucloxacillinRegions = prescriptionService.GetAverageActCostPerRegion("0501012G0");
            // Get average cost for country
            decimal averageFlucloxacillinNational = prescriptionService.GetAverageActCost("0501012G0");
            Console.WriteLine("National: £" + averageFlucloxacillinNational.ToString("#.##"));
            foreach(var r in averageFlucloxacillinRegions)
            {
                Console.WriteLine(r.Key + ": £" + r.Value.ToString("#.##") + "; " 
                    + (r.Value - averageFlucloxacillinNational).ToString("#.##"));
            }


            Console.ReadLine();
        }

        private static void processOnce(PrescriptionsService prescriptionService)
        {

        }
    }
}

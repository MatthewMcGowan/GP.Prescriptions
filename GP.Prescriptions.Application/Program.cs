namespace GP.Prescriptions.Application
{
    using System;
    using System.Linq;

    using BusinessObjects.Classes;

    using BusinessLayer.Services.Core;

    using BusinessObjects.Extensions;

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Performing startup...");
            //Create instances of practice service and prescription service
            var practicesService = new PracticesService();
            var prescriptionService = new PrescriptionsService(practicesService.Practices);
            Console.WriteLine("Startup completed.");
            if (askBooleanQuestion("Process all at once?"))
            {
                ProcessOnce(practicesService, prescriptionService);
            }
            else
            {
                Process(practicesService, prescriptionService);
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

        private static void Process(PracticesService practicesService, PrescriptionsService prescriptionService)
        {

            // Find out how many practices there are in London
            Console.WriteLine("How many practices are in London?");
            int practicesInLondon = practicesService.GetPracticeCountByRegion(Region.London);
            Console.WriteLine(practicesInLondon);

            // Find out the average national cost of a peppermint oil prescription
            Console.WriteLine("What was the average actual cost of all peppermint oil prescriptions?");
            decimal averagePepermintOilCost = prescriptionService.GetAverageActCost("0102000T0");
            Console.WriteLine(averagePepermintOilCost.ToString("£0.00"));

            // Find the 5 highest spending postcodes
            Console.WriteLine("Which 5 post codes have the highest actual spend, and how much did each spend in total?");
            // Get postcode spends
            var totalPostcodeSpends = prescriptionService.GetTotalSpendPerPostcode();
            // Get top 5
            var topFive = totalPostcodeSpends.OrderByDescending(p => p.Value).Take(5).ToList();
            // Write to console
            topFive.ForEach(p => Console.WriteLine(p.Key + " " + p.Value.ToString("£0.00")));

            // Find average price of Flucloxacillin
            Console.WriteLine(
                "For each region, what was the average price per prescription of Flucloxacillin,"
                + " and how did this vary from the national mean?");
            // Get average cost per region
            var averageFlucloxacillinRegions = prescriptionService.GetAverageActCostPerRegion("0501012G0");
            // Get average cost for country
            decimal averageFlucloxacillinNational = prescriptionService.GetAverageActCost("0501012G0");
            // Write to console
            Console.WriteLine("National: " + averageFlucloxacillinNational.ToString("£0.00"));
            averageFlucloxacillinRegions.ForEach(
                r =>
                Console.WriteLine(
                    r.Key + " " + r.Value.ToString("£0.00") + "; "
                    + (r.Value - averageFlucloxacillinNational).ToString("£0.00")));

            // Find by region the percentage difference between the NIC and Act Cost for
            Console.WriteLine(
                "For each region for Simeticone, what was the average Actual Cost "
                + "as a percentage of the average Net Ingredient Cost?");
            var actPercentageOfNic = prescriptionService.GetFractionActCostOfNicByRegion("0103050E0");
            actPercentageOfNic.ForEach(r => Console.WriteLine(r.Key + " " + r.Value.ToString("0.00%")));

            Console.ReadLine();
        }

        private static void ProcessOnce(PracticesService practicesService, PrescriptionsService prescriptionService)
        {
            // Read prescriptions and get answer to all questions first
            Console.WriteLine("Processing...");



            // Find out how many practices there are in London using practices service
            Console.WriteLine("How many practices are in London?");
            int practicesInLondon = practicesService.GetPracticeCountByRegion(Region.London);
            Console.WriteLine(practicesInLondon);

            // Answer other questions 

        }
    }
}

// Program 1B
// CIS 200-10
// Summer 2015
// Due: 6/3/2015
// By: Todd Lasley & Dr. Wright

// File: TestParcels.cs
// Uses LINQ queries to select Parcel objects with certain criteria.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Prog1
{
    class TestParcels
    {
        // Precondition:  None
        // Postcondition: Parcels have been created and displayed
        static void Main(string[] args)
        {
            // Test Data - Magic Numbers OK
            Address a1 = new Address("John Smith", "123 Any St.", "Apt. 45",
                "Louisville", "KY", 40202); // Test Address 1
            Address a2 = new Address("Jane Doe", "987 Main St.", "",
                "Beverly Hills", "CA", 90210); // Test Address 2
            Address a3 = new Address("James Kirk", "654 Roddenberry Way", "Suite 321",
                "El Paso", "TX", 79901); // Test Address 3
            Address a4 = new Address("John Crichton", "678 Pau Place", "Apt. 7",
                "Portland", "ME", 04101); // Test Address 4

            //extra Address objects added
            Address a5 = new Address("Todd Lasley", "550 Ruggles Place", "Apt. 6",
                "Louisville", "KY", 40208); // Test Address 5
            Address a6 = new Address("Michael Myers", "42 Elm Ave.", "",
                "San Francisco", "CA", 85742); // Test Address 6
            Address a7 = new Address("Jared Taylor", "127 St. Route 271", "",
                "Hawesville", "KY", 42348); // Test Address 7
            Address a8 = new Address("Smitty Werbenjagermanjensen", "401 That St.", "Apt. 5",
                "Cincinatti", "OH", 12354); // Test Address 8

            // Letter test objects
            Letter letter1 = new Letter(a1, a2, 3.95M); //letter1
            Letter letter2 = new Letter(a3, a6, 4.58M); //letter2
            Letter letter3 = new Letter(a4, a5, 7.5M); //letter3
            Letter letter4 = new Letter(a5, a2, 5.8M); //letter4

            // Ground test objects
            GroundPackage gp1 = new GroundPackage(a5, a8, 14, 10, 5, 12.5); //ground 1
            GroundPackage gp2 = new GroundPackage(a3, a4, 24, 16, 7, 54); //ground 2
            GroundPackage gp3 = new GroundPackage(a6, a3, 30, 8, 7.5, 24); //ground 3
            GroundPackage gp4 = new GroundPackage(a7, a8, 21, 17, 12.5, 41); //ground 4

            // Next Day test objects
            NextDayAirPackage ndap1 = new NextDayAirPackage(a1, a2, 24, 17, 30, //next day 1
                83, 4.53M);                                                     
            NextDayAirPackage ndap2 = new NextDayAirPackage(a4, a1, 18, 12, 19, //next day 2
                67, 5.86M);
            NextDayAirPackage ndap3 = new NextDayAirPackage(a7, a8, 30, 3, 21, //next day 3
                23, 9.24M);
            NextDayAirPackage ndap4 = new NextDayAirPackage(a1, a6, 22, 16, 17, //next day 4
                78, 6.88M);

            // Two Day test objects
            TwoDayAirPackage tdap1 = new TwoDayAirPackage(a4, a1, 46.5, 39.5, 28.0, //two day 1
                60.5, TwoDayAirPackage.Delivery.Saver);
            TwoDayAirPackage tdap2 = new TwoDayAirPackage(a3, a1, 57.3, 27.7, 23.0, //two day 2
                78.4, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap3 = new TwoDayAirPackage(a8, a2, 28.4, 23.9, 19.8, //two day 3
                80.5, TwoDayAirPackage.Delivery.Early);
            TwoDayAirPackage tdap4 = new TwoDayAirPackage(a5, a3, 60.2, 31.8, 26.8, //two day 4
                35.7, TwoDayAirPackage.Delivery.Saver);

            List<Parcel> parcels;      // List of test parcels

            parcels = new List<Parcel>();

            parcels.Add(letter1); // Populate list
            parcels.Add(letter2);
            parcels.Add(letter3);
            parcels.Add(letter4);
            
            parcels.Add(gp1);
            parcels.Add(gp2);
            parcels.Add(gp3);
            parcels.Add(gp4);

            parcels.Add(ndap1);
            parcels.Add(ndap2);
            parcels.Add(ndap3);
            parcels.Add(ndap4);

            parcels.Add(tdap1);
            parcels.Add(tdap2);
            parcels.Add(tdap3);
            parcels.Add(tdap4);

            Console.WriteLine("Original List:");
            Console.WriteLine("====================");
            foreach (Parcel p in parcels)
            {
                Console.WriteLine(p);
                Console.WriteLine("====================");
            }
            Pause();

            //Select all Parcels and order by destination zip (descending)
            Console.WriteLine("Select all Parcels and order by destination zip (descending)");
            Console.WriteLine("====================");
            
            //LINQ query used to order by destination zip (descending)
            var zips =
                from p in parcels
                orderby p.DestinationAddress.Zip descending
                select p;
            
            foreach (var zip in zips)
            {
                Console.WriteLine(zip);
                Console.WriteLine("====================");
            }
            Pause();

            //Select all Parcels and order by cost (ascending)
            Console.WriteLine("Select all Parcels and order by cost (ascending)");
            Console.WriteLine("====================");

            //LINQ query used to order by destination zip (descending)
            var costs =
                from p in parcels
                orderby p.CalcCost()
                select p;

            foreach (var cost in costs)
            {
                Console.WriteLine(cost);
                Console.WriteLine("====================");
            }
            Pause();

            //Select all Parcels and order by Parcel type (ascending) and then cost (descending)
            Console.WriteLine("Select all Parcels and order by Parcel type (ascending)\n and then cost (descending)");
            Console.WriteLine("====================");

            //LINQ query used to order by Parcel type (ascending) and then cost (descending)
            var types =
                from p in parcels
                orderby p.GetType().ToString(), p.CalcCost() descending
                select p;

            foreach (var type in types)
            {
                Console.WriteLine(type);
                Console.WriteLine("====================");
            }
            Pause();

            //Select all AirPackage objects that are heavy and order by weight (descending)
            Console.WriteLine("Select all AirPackage objects that are heavy and order by weight (descending)");
            Console.WriteLine("====================");

            //LINQ query used to select AirPackages and list them by weight in descending order
            var airpackages =
                from p in parcels
                let ap = p as AirPackage //downcasting so it will only select objects of type AirPackage
                where p == ap && ap.IsHeavy()
                orderby ap.Weight descending
                select ap;

            foreach (var airpackage in airpackages)
            {
                Console.WriteLine(airpackage);
                Console.WriteLine("====================");
            }
            Pause();
       }

        // Precondition:  None
        // Postcondition: Pauses program execution until user presses Enter and
        //                then clears the screen
        public static void Pause()
        {
            Console.WriteLine("Press Enter to Continue...");
            Console.ReadLine();

            Console.Clear(); // Clear screen
        }
    }
}

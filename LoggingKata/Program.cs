using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");

            var lines = File.ReadAllLines(csvPath);
            if (lines.Length == 0)
            {
                logger.LogError("No lines found in the CSV file");
            }
            else if (lines.Length == 1 )
            {
                logger.LogWarning("Only 1 line found in CSV file");
            }

            logger.LogInfo($"Lines: {lines[0]}");

            var parser = new TacoParser();
        
            var locations = lines.Select(parser.Parse).ToArray();


            // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
            // HINT:  You'll need two nested forloops


            TacoBell Tacobell = new TacoBell();
            Tacobell.Location = new Point() { Latitude = 0, Longitude = 0 };

            ITrackable tacoBell1 = null;
            ITrackable tacoBell2 = null;

            double CurrentDistance = 0;

            for (int i = 0; i < locations.Length; i++)
            {
                ITrackable LocA = locations[i];
                GeoCoordinate LocAPosition = new GeoCoordinate();
                LocAPosition.Latitude = LocA.Location.Latitude;
                LocAPosition.Longitude = LocA.Location.Longitude;
                double MaxDistance = 0;
                for (int e = 0; e < locations.Length; e++)
                {

                    ITrackable LocB = locations[e];
                    GeoCoordinate LocBPosition = new GeoCoordinate();
                    LocBPosition.Latitude = LocB.Location.Latitude;
                    LocBPosition.Longitude = LocB.Location.Longitude;
                    MaxDistance = LocAPosition.GetDistanceTo(LocBPosition);

                    if(MaxDistance >= CurrentDistance)
                    {
                        CurrentDistance = MaxDistance;
                        tacoBell1 = LocA;
                        tacoBell2 = LocB;
                       
                    }

                }  

            }
            Console.WriteLine(tacoBell1.Name);
            Console.WriteLine(tacoBell2.Name);
            Console.WriteLine(CurrentDistance );
        }
    }
}
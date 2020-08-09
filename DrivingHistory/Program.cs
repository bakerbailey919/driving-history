using System;
using System.Collections.Generic;
using System.IO;

namespace DrivingHistory
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                Console.WriteLine("Please pass a filename");
                return;
            }

            string projectDirectory = Environment.CurrentDirectory;  
            string filename = args[0];
            string fullPath = Path.Combine(projectDirectory, filename);

            if (!File.Exists(fullPath))
            {
                Console.WriteLine("Input file not found, please try again.");
                return;
            }

            FileAccess fileAccess = new FileAccess();

            List<string> lines = fileAccess.ReadFile(fullPath);

            TripHandler tripHandler = new TripHandler();
            Dictionary<string, DriverInfo> drivers = tripHandler.ParseFileData(lines);
            List<string> result = tripHandler.GenerateTripOutput(drivers);
            tripHandler.DisplayOutput(result);
        }
    }
}

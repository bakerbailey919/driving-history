using DrivingHistory.Interfaces;
using DrivingHistory.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DrivingHistory
{
    public class TripHandler : ITripHandler
    {
        public List<string> GenerateTripOutput(Dictionary<string, DriverInfo> driverInfo)
        {
            List<string> output = new List<string>();
            foreach (KeyValuePair<string, DriverInfo> item in driverInfo.OrderByDescending(key => key.Value.MilesTraveled))
            {
                string outputString = item.Key + ": " + Math.Round(item.Value.MilesTraveled, 0) + " miles";
                if (item.Value.MilesTraveled > 0)
                {
                    outputString += " @ " + Math.Round(item.Value.MilesTraveled / item.Value.HoursTraveled, 0) + " mph";
                }
                output.Add(outputString);
            }
            return output;
        }

        public void DisplayOutput(List<string> output)
        {
            foreach(string item in output)
            {
                Console.WriteLine(item);
            }
        }

        public Dictionary<string, DriverInfo> ParseFileData(List<string> fileLines)
        {
            Dictionary<string, DriverInfo> driverInfo = new Dictionary<string, DriverInfo>();
            foreach (string line in fileLines)
            {
                string[] split = line.Split(' ');

                if (split[Constants.CommandIndex] == Constants.DriverCommand)
                {
                    DriverInfo info = new DriverInfo(split[Constants.DriverNameIndex]);
                    driverInfo.Add(info.DriverName, info);
                }
                else if (split[Constants.CommandIndex] == Constants.TripCommand)
                {
                    if (driverInfo.ContainsKey(split[Constants.DriverNameIndex]))
                    {
                        DriverInfo info = driverInfo[split[Constants.DriverNameIndex]];
                        info.AddTrip(split);
                    }
                }
            }
            return driverInfo;
        }
    }
}

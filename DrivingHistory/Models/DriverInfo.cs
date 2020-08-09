using DrivingHistory.Models;
using System;

namespace DrivingHistory
{
    public class DriverInfo
    {
        public string DriverName { get; private set; }
        public double MilesTraveled { get; private set; }
        public double HoursTraveled { get; private set; }

        public DriverInfo()
        {

        }

        public DriverInfo(string driverName)
        {
            DriverName = driverName;
            MilesTraveled = 0;
            HoursTraveled = 0;
        }

        public DriverInfo(string driverName, double milesTraveled, double hoursTraveled)
        {
            DriverName = driverName;
            MilesTraveled = milesTraveled;
            HoursTraveled = hoursTraveled;
        }

        public void AddTrip(string[] tripInfo)
        {
            DateTime parsedEndTime = DateTime.Parse(tripInfo[Constants.EndTimeIndex]);
            DateTime parsedStartTime = DateTime.Parse(tripInfo[Constants.StartTimeIndex]);
            double hoursTraveled = parsedEndTime.Subtract(parsedStartTime).TotalHours;
            double speed = Convert.ToDouble(tripInfo[Constants.MilesIndex]) / hoursTraveled;
            if (speed > 5 && speed < 100)
            {
                MilesTraveled += Convert.ToDouble(tripInfo[Constants.MilesIndex]);
                HoursTraveled += hoursTraveled;
            }
        }
    }
}

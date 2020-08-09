using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace DrivingHistory.Tests
{
    [TestClass]
    public class TripHandlerTest
    {
        [TestMethod]
        public void ParseFileDataHandlesEmptyList()
        {
            TripHandler tripHandler = new TripHandler();
            List<string> input = new List<string>();

            Dictionary<string, DriverInfo> result = tripHandler.ParseFileData(input);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ParseFileDataAddsDrivers()
        {
            TripHandler trip = new TripHandler();
            List<string> input = new List<string>();
            input.Add("Driver Kumi");
            input.Add("Driver Dan");

            Dictionary<string, DriverInfo> result = trip.ParseFileData(input);

            Assert.AreEqual(true, result.ContainsKey("Kumi"));
            Assert.AreEqual(true, result.ContainsKey("Dan"));
        }

        [TestMethod]
        public void ParseFileDataReturnsEmptyDictionaryIfNoDriverAdded()
        {
            TripHandler trip = new TripHandler();
            List<string> input = new List<string>();
            input.Add("Trip Dan 07:15 07:45 17.3");
         
            Dictionary<string, DriverInfo> result = trip.ParseFileData(input);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void ParseFileDataHandlesMultipleTrips()
        {
            TripHandler trip = new TripHandler();
            List<string> input = new List<string>();
            input.Add("Driver Dan");
            input.Add("Trip Dan 07:15 07:45 17.3");
            input.Add("Trip Dan 06:12 06:32 21.8");

            Dictionary<string, DriverInfo> result = trip.ParseFileData(input);

            Assert.AreEqual(39.1, result["Dan"].MilesTraveled);
        }

        [TestMethod]
        public void ParseFileDataHandlesMultipleDriversWithTrips()
        {
            TripHandler trip = new TripHandler();
            List<string> input = new List<string>();
            input.Add("Driver Dan");
            input.Add("Driver Lauren");
            input.Add("Trip Dan 07:15 07:45 17.3");
            input.Add("Trip Lauren 12:01 13:16 42.0");

            Dictionary<string, DriverInfo> result = trip.ParseFileData(input);

            Assert.AreEqual(17.3, result["Dan"].MilesTraveled);
            Assert.AreEqual(42.0, result["Lauren"].MilesTraveled);
        }

        [TestMethod]
        public void GenerateTripOutputReturnsExpectedList()
        {
            TripHandler trip = new TripHandler();
            DriverInfo driverInfo = new DriverInfo("Dan", 39, 2);
            
            Dictionary<string, DriverInfo> input = new Dictionary<string, DriverInfo>();
            input.Add("Dan", driverInfo);


            List<string> result = trip.GenerateTripOutput(input);

            Assert.AreEqual("Dan: 39 miles @ 20 mph", result[0]);
        }

        [TestMethod]
        public void GenerateTripHandlesEmptyDictionary()
        {
            TripHandler trip = new TripHandler();
            Dictionary<string, DriverInfo> input = new Dictionary<string, DriverInfo>();

            List<string> result = trip.GenerateTripOutput(input);

            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GenerateTripOutputReturnsInDescendingOrder()
        {
            TripHandler trip = new TripHandler();
            DriverInfo driverDanInfo = new DriverInfo("Dan", 39, 2);
            DriverInfo driverLaurenInfo = new DriverInfo("Lauren", 50, 2);

            Dictionary<string, DriverInfo> input = new Dictionary<string, DriverInfo>();
            input.Add("Dan", driverDanInfo);
            input.Add("Lauren", driverLaurenInfo);

            List<string> result = trip.GenerateTripOutput(input);

            Assert.AreEqual("Lauren: 50 miles @ 25 mph", result[0]);
            Assert.AreEqual("Dan: 39 miles @ 20 mph", result[1]);
        }

        [TestMethod]
        public void GenerateTripOutputHandlesZeroMiles()
        {
            TripHandler trip = new TripHandler();
            DriverInfo driverInfo = new DriverInfo("Dan", 0, 0);

            Dictionary<string, DriverInfo> input = new Dictionary<string, DriverInfo>();
            input.Add("Dan", driverInfo);

            List<string> result = trip.GenerateTripOutput(input);

            Assert.AreEqual("Dan: 0 miles", result[0]);
        }

    }
}

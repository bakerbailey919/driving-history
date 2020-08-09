using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace DrivingHistory.Tests
{
    [TestClass]
    public class DriverInfoTest
    {
        [TestMethod]
        public void AddTripDoesNotUpdateIfSpeedLessThanFive()
        {
            DriverInfo driverInfo = new DriverInfo();
            string[] input = new string[] { "Trip", "Dan", "07:15", "07:45", "2" };

           driverInfo.AddTrip(input);

            Assert.AreEqual(0, driverInfo.MilesTraveled);
            Assert.AreEqual(0, driverInfo.HoursTraveled);
        }

        [TestMethod]
        public void AddTripDoesNotUpdateIfSpeedGreaterThanOneHundred()
        {
            DriverInfo driverInfo = new DriverInfo();
            string[] input = new string[] { "Trip", "Dan", "07:15", "07:45", "200" };

            driverInfo.AddTrip(input);

            Assert.AreEqual(0, driverInfo.MilesTraveled);
            Assert.AreEqual(0, driverInfo.HoursTraveled);
        }

        [TestMethod]
        public void AddTripUpdatesIfSpeedIsValid()
        {
            DriverInfo driverInfo = new DriverInfo();
            string[] input = new string[] { "Trip", "Dan", "07:15", "07:45", "17.3" };

            driverInfo.AddTrip(input);

            Assert.AreEqual(17.3, driverInfo.MilesTraveled);
            Assert.AreEqual(0.5, driverInfo.HoursTraveled);
        }

        [TestMethod]
        public void DriverInfoConstructorWithDriverName()
        {
            DriverInfo driverInfo = new DriverInfo("Dan");
          
            Assert.AreEqual("Dan", driverInfo.DriverName);
        }

        [TestMethod]
        public void DriverInfoConstructorWithAllParameters()
        {
            DriverInfo driverInfo = new DriverInfo("Dan", 50, 2);

            Assert.AreEqual("Dan", driverInfo.DriverName);
            Assert.AreEqual(50, driverInfo.MilesTraveled);
            Assert.AreEqual(2, driverInfo.HoursTraveled);
        }
    }
}
  

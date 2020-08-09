using DrivingHistory.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DrivingHistory.Tests
{
    [TestClass]
    public class ConstantsTest
    {
        [TestMethod]
        public void CommandsAreExpectedValues()
        {
            Assert.AreEqual("Driver", Constants.DriverCommand);
            Assert.AreEqual("Trip", Constants.TripCommand); 
        }

        [TestMethod]
        public void IndexesAreExpectedValues()
        {
            Assert.AreEqual(0, Constants.CommandIndex);
            Assert.AreEqual(1, Constants.DriverNameIndex);
            Assert.AreEqual(2, Constants.StartTimeIndex);
            Assert.AreEqual(3, Constants.EndTimeIndex);
            Assert.AreEqual(4, Constants.MilesIndex);
        }
    }
}

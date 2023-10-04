using Agency.Exceptions;
using Agency.Models;
using Agency.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agency.Tests.Models
{
    [TestClass]
    public class BusTests
    {
        [TestMethod]
        [DataRow(BusData.CapacityTooSmall)]
        [DataRow(BusData.CapacityTooBig)]
        public void Constructor_Should_ThrowException_When_PassengerCapacityOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bus(
                    id: 1,
                    passengerCapacity: testValue,
                    pricePerKilometer: BusData.ValidPricePerKilometerValue,
                    hasFreeTv: true));
        }

        [TestMethod]
        [DataRow(BusData.PricePerKilometerValueTooSmall)]
        [DataRow(BusData.PricePerKilometerValueTooBig)]
        public void Constructor_Should_ThrowException_When_PricePerKmOutOfBounds(double testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Bus(
                    id: 1,
                    passengerCapacity: BusData.ValidCapacity,
                    pricePerKilometer: testValue,
                    hasFreeTv: true));
        }
    }
}

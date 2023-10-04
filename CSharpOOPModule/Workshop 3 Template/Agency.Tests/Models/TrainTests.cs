using Agency.Exceptions;
using Agency.Models;
using Agency.Tests.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Agency.Tests.Models
{
    [TestClass]
    public class TrainTests
    {
        [TestMethod]
        [DataRow(TrainData.CapacityTooSmall)]
        [DataRow(TrainData.CapacityTooBig)]
        public void Constructor_Should_ThrowException_When_PassengerCapacityOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Train(
                    id: 1,
                    passengerCapacity: testValue,
                    pricePerKilometer: TrainData.ValidPricePerKilometerValue,
                    carts: TrainData.ValidCartsValue));
        }

        [TestMethod]
        [DataRow(TrainData.PricePerKilometerValueTooSmall)]
        [DataRow(TrainData.PricePerKilometerValueTooBig)]
        public void Constructor_Should_ThrowException_When_PricePerKmOutOfBounds(double testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Train(
                    id: 1,
                    passengerCapacity: TrainData.ValidTrainCapacity,
                    pricePerKilometer: testValue,
                    carts: TrainData.ValidCartsValue));
        }

        [TestMethod]
        [DataRow(TrainData.CartsValueTooSmall)]
        [DataRow(TrainData.CartsValueTooBig)]
        public void Constructor_Should_Throw_When_CartsCountOutOfBounds(int testValue)
        {
            Assert.ThrowsException<InvalidUserInputException>(() =>
                new Train(
                    id: 1,
                    passengerCapacity: TrainData.ValidTrainCapacity,
                    pricePerKilometer: TrainData.ValidPricePerKilometerValue,
                    carts: testValue));
        }
    }
}

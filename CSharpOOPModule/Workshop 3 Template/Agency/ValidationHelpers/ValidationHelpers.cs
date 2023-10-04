using Agency.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agency.ValidationHelpers
{
    public static class ValidationHelpers
    {
        public static void PassengerCapacity(int capacity, int PassengerCapacityMinValue, int PassengerCapacityMaxValue, string type)
        {
            if (capacity < PassengerCapacityMinValue || capacity > PassengerCapacityMaxValue)
            {
                throw new InvalidUserInputException($"A {type} cannot have less than {PassengerCapacityMinValue} passengers or more than {PassengerCapacityMaxValue} passengers");
            }
        }
        public static void PricePerKilometer(double pricePerKilometer, double PricePerKilometerMinValue, double PricePerKilometerMaxValue)
        {
            if (pricePerKilometer < PricePerKilometerMinValue || pricePerKilometer > PricePerKilometerMaxValue)
            {
                throw new InvalidUserInputException($"A vehicle with a price per kilometer lower than ${PricePerKilometerMinValue:F2} or higher than ${PricePerKilometerMaxValue:F2} cannot exist!");
            }
        }
        public static void PriceNotNegative(double price)
        {
            if (price < 0)
            {
                throw new InvalidUserInputException($"Value of 'costs must be a positive number. Actual value: {price:F2}.");
            }
        }
        public static void StartingLocationNameLength(string destinationName, int StartLocationMinLength, int StartLocationMaxLength)
        {
            if (destinationName.Length < 5 || destinationName.Length > 25)
            {
                throw new InvalidUserInputException($"The length of StartLocation must be between {StartLocationMinLength} and {StartLocationMaxLength} symbols.");
            }
        }
        public static void DestinationNameLength(string destinationName, int StartLocationMinLength, int StartLocationMaxLength)
        {
            if (destinationName.Length < 5 || destinationName.Length > 25)
            {
                throw new InvalidUserInputException($"The length of Destination must be between {StartLocationMinLength} and {StartLocationMaxLength}");
            }
        }
        public static void DistanceCheck(int distance, int DistanceMinValue, int DistanceMaxValue)
        {
            if (distance < DistanceMinValue || distance > DistanceMaxValue)
            {
                throw new InvalidUserInputException($"The Distance cannot be less than {DistanceMinValue} or more than {DistanceMaxValue} kilometers.");
            }
        }
        public static void CartsNumber(int cartsCount)
        {
            if (cartsCount < 1 || cartsCount > 15)
            {
                throw new InvalidUserInputException($"A train cannot have less than 1 cart or more than 15 carts.");
            }
        }
        public static void VehicleMaxPassengers(int passengers)
        {
            if (passengers < 1 || passengers > 800)
            {
                throw new InvalidUserInputException($"A vehicle with less than 1 passengers or more than 800 passengers cannot exist!");
            }
        }
    }
}

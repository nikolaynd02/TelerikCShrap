using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Airplane : Vehicle, IAirplane
    {
        private const int PassengerCapacityMinValue = 1;
        private const int PassengerCapacityMaxValue = 800;
        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;

        private bool isLowCost;

        public Airplane(int id, int passengerCapacity, double pricePerKilometer, bool isLowCost) : base(id, passengerCapacity, pricePerKilometer)
        {
            ValidationHelpers.ValidationHelpers.PassengerCapacity(passengerCapacity, PassengerCapacityMinValue, PassengerCapacityMaxValue, "Airplane");
            ValidationHelpers.ValidationHelpers.PricePerKilometer(pricePerKilometer, PricePerKilometerMinValue, PricePerKilometerMaxValue);
            IsLowCost = isLowCost;
        }

        public bool IsLowCost
        {
            get { return isLowCost; }
            private set
            {
                isLowCost = value;
            }
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Airplane----");
            output.AppendLine($"Passenger capacity: {PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {PricePerKilometer}");
            output.AppendLine($"Is low - cost: {IsLowCost}");

            return output.ToString().Trim();
        }
    }
}

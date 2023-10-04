using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Bus : Vehicle, IBus
    {
        private const int PassengerCapacityMinValue = 10;
        private const int PassengerCapacityMaxValue = 50;
        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;

        private bool hasFreeTv;
        public Bus(int id, int passengerCapacity, double pricePerKilometer, bool hasFreeTv) : base(id, passengerCapacity, pricePerKilometer)
        {
            ValidationHelpers.ValidationHelpers.PassengerCapacity(passengerCapacity, PassengerCapacityMinValue, PassengerCapacityMaxValue, "Bus");
            ValidationHelpers.ValidationHelpers.PricePerKilometer(pricePerKilometer, PricePerKilometerMinValue, PricePerKilometerMaxValue);
            HasFreeTv = hasFreeTv;
        }

        public bool HasFreeTv
        {
            get { return hasFreeTv; }
            private set
            {
                hasFreeTv = value;
            }
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Bus----");
            output.AppendLine($"Passenger capacity: {PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {PricePerKilometer}");
            output.AppendLine($"Has free TV: {HasFreeTv}");

            return output.ToString().Trim();
        }
    }
}

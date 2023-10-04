using Agency.Models.Contracts;
using System;
using System.Text;

namespace Agency.Models
{
    public class Train : Vehicle, ITrain
    {
        private const int PassengerCapacityMinValue = 30;
        private const int PassengerCapacityMaxValue = 150;
        private const double PricePerKilometerMinValue = 0.10;
        private const double PricePerKilometerMaxValue = 2.50;
        private const int CartsMinValue = 1;
        private const int CartsMaxValue = 15;

        private int carts;

        public Train(int id, int passengerCapacity, double pricePerKilometer, int carts) : base(id, passengerCapacity, pricePerKilometer)
        {
            ValidationHelpers.ValidationHelpers.PassengerCapacity(passengerCapacity, PassengerCapacityMinValue, PassengerCapacityMaxValue, "Train");
            ValidationHelpers.ValidationHelpers.PricePerKilometer(pricePerKilometer, PricePerKilometerMinValue, PricePerKilometerMaxValue);
            ValidationHelpers.ValidationHelpers.CartsNumber(carts);
            Carts = carts;
        }

        public int Carts
        {
            get { return carts; }
            private set
            {
                carts = value;
            }
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Train----");
            output.AppendLine($"Passenger capacity: {PassengerCapacity}");
            output.AppendLine($"Price per kilometer: {PricePerKilometer}");
            output.AppendLine($"Carts amount: {Carts}");

            return output.ToString().Trim();
        }
    }
}

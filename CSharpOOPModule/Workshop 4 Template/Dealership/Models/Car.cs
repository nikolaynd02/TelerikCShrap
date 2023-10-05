
using Dealership.Models.Contracts;
using System;
using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const string InvalidSeatsError = "Seats must be between 1 and 10!";

        private int seats;

        public Car(string make, string model, decimal price, int seats) : base(make, model, price, VehicleType.Car, (int)VehicleType.Car)
        {
            Seats = seats;
        }

        public int Seats
        {
            get { return seats; }
            private set
            {
                Validator.ValidateIntRange(value, MinSeats, MaxSeats, InvalidSeatsError);

                seats = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"  Seats: {Seats}");
            return output.ToString();
        }
    }
}

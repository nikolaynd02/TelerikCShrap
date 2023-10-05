
using Dealership.Models.Contracts;
using System;
using System.Text;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";
        
        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity) : base(make, model, price, VehicleType.Truck, (int)VehicleType.Truck)
        {
            WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get { return weightCapacity; }
            private set
            {
                Validator.ValidateIntRange(value, MinCapacity, MaxCapacity, InvalidCapacityError);

                weightCapacity = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"  Weight Capacity: {WeightCapacity}t");
            return output.ToString();
        }

    }
}

using System;
using System.Text;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Journey : IJourney
    {
        private const int StartLocationMinLength = 5;
        private const int StartLocationMaxLength = 25;
        private const int DestinationMinLength = 5;
        private const int DestinationMaxLength = 25;
        private const int DistanceMinValue = 5;
        private const int DistanceMaxValue = 5000;

        private int id;
        private string from;
        private string destination;
        private int distance;
        private IVehicle vehicle;

        public Journey(int id, string from, string to, int distance, IVehicle vehicle)
        {
            ValidationHelpers.ValidationHelpers.StartingLocationNameLength(from, StartLocationMinLength, StartLocationMaxLength);
            ValidationHelpers.ValidationHelpers.DestinationNameLength(to, DestinationMinLength, DestinationMaxLength);
            ValidationHelpers.ValidationHelpers.DistanceCheck(distance, DistanceMinValue, DistanceMaxValue);
            Id = id;
            StartLocation = from;
            Destination = to;
            Distance = distance;
            Vehicle = vehicle;
        }

        public string StartLocation
        {
            get { return from; }
            private set { from = value; }
        }

        public string Destination
        {
            get { return destination; }
            private set { destination = value; }
        }

        public int Distance
        {
            get { return distance; }
            private set { distance = value; }
        }

        public IVehicle Vehicle
        {
            get { return vehicle; }
            private set { vehicle = value; }
        }

        public int Id
        {
            get { return id; }
            private set { id = value; }
        }

        public double CalculatePrice()
        {
            return Distance * Vehicle.PricePerKilometer;
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Journey----");
            output.AppendLine($"Start location: {StartLocation}");
            output.AppendLine($"Distance: {Distance}");
            output.AppendLine($"Travel cost: {CalculatePrice():F2}");

            return output.ToString().Trim();
        }
    }
}

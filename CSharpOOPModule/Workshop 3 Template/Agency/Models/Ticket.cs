using System;
using System.Text;
using Agency.Models.Contracts;

namespace Agency.Models
{
    public class Ticket : ITicket
    {
        private int id;
        private IJourney jorney;
        private double administrativeCosts;

        public Ticket(int id, IJourney journey, double administrativeCosts)
        {
            Id = id;
            Journey = journey;
            AdministrativeCosts = administrativeCosts;
            ValidationHelpers.ValidationHelpers.PriceNotNegative(administrativeCosts);
        }

        public double AdministrativeCosts
        {
            get { return administrativeCosts; }
            private set { administrativeCosts = value; }
        }

        public IJourney Journey
        {
            get { return jorney; }
            set { jorney = value; }
        }

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        public double CalculatePrice()
        {
            return AdministrativeCosts * Journey.CalculatePrice();
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine("Ticket----");
            output.AppendLine($"Destination: {Journey.Destination}");
            output.AppendLine($"Price: {CalculatePrice():F2}");

            return output.ToString().Trim();
        }
    }
}

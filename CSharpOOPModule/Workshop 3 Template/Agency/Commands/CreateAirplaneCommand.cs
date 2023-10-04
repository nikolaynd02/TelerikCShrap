using Agency.Commands.Abstracts;
using Agency.Core.Contracts;
using Agency.Exceptions;
using System;
using System.Collections.Generic;

namespace Agency.Commands
{
    public class CreateAirplaneCommand : BaseCommand
    {
        public const int ExpectedNumberOfArguments = 3;

        public CreateAirplaneCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < ExpectedNumberOfArguments)
            {
                throw new InvalidUserInputException($"Invalid number of arguments. Expected: {ExpectedNumberOfArguments}, Received: {this.CommandParameters.Count}");
            }

            int passengerCapacity = this.ParseIntParameter(this.CommandParameters[0], "passengerCapacity");
            double pricePerKilometer = this.ParseDoubleParameter(this.CommandParameters[1], "pricePerKilometer");
            bool hasFreeTv = this.ParseBoolParameter(this.CommandParameters[2], "hasFreeTv");

            var airplane = this.Repository.CreateAirplane(passengerCapacity, pricePerKilometer, hasFreeTv);
            return $"Vehicle with ID {airplane.Id} was created.";
        }
    }
}

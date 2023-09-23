using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateToothpasteCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateToothpasteCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            IList<string> arguments = this.CommandParameters;

            return CreateToothpaste(arguments);

        }
        //CreateToothpaste: White Colgate 10.99 Men calcium,fluorid
        private string CreateToothpaste(IList<string> arguments)
        {
            string name = arguments[0];
            string brand = arguments[1];
            bool priceIsvalid = decimal.TryParse(arguments[2], out decimal price);
            if (!priceIsvalid)
            {
                throw new ArgumentException("Price is not valid.");
            }
            bool genderIsValid = Enum.TryParse(arguments[3], out GenderType gender);
            if (!genderIsValid)
            {
                throw new ArgumentException("Gender is not valid.");
            }
            string ingredients = arguments[4];


            if (this.Repository.ProductExists(arguments[0]))
            {
                throw new ArgumentException(string.Format($"Toothpaste with name {arguments[0]} already exists!"));
            }

            this.Repository.CreateToothpaste(name, brand, price, gender, ingredients);

            return $"Toothpaste with name {name} was created!";

        }

    }
}

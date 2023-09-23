using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;

namespace Cosmetics.Commands
{
    public class CreateShampooCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 6;

        public CreateShampooCommand(IList<string> parameters, IRepository repository)
            : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            IList<string> arguments = this.CommandParameters;

            return CreateShampoo(arguments);

        }
        //CreateShampoo: MyMan Nivea 10.99 Men 1000 EveryDay
        private string CreateShampoo(IList<string> arguments)
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
            bool mellilitresIsvalid = int.TryParse(arguments[4], out int millilitres );
            if (!mellilitresIsvalid)
            {
                throw new ArgumentException("Mellilitres is not valid.");
            }
            bool usageIsValid = Enum.TryParse(arguments[5], out UsageType usage);
            if (!usageIsValid)
            {
                throw new ArgumentException("UsageType is not valid.");
            }


            if (this.Repository.ProductExists(arguments[0]))
            {
                throw new ArgumentException(string.Format($"Shampoo with name {arguments[0]} already exists!"));
            }

            this.Repository.CreateShampoo(name, brand, price, gender, millilitres, usage);

            return $"Shampoo with name {name} was created!";

        }

    }
}

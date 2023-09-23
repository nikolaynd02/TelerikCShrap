using Cosmetics.Core.Contracts;
using Cosmetics.Helpers;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Commands
{
    public class CreateCreamCommand : BaseCommand
    {
        private const int ExpectedNumberOfArguments = 5;

        public CreateCreamCommand(IList<string> parameters, IRepository repository)
             : base(parameters, repository)
        {
        }

        public override string Execute()
        {
            ValidationHelper.ValidateArgumentsCount(this.CommandParameters, ExpectedNumberOfArguments);

            IList<string> arguments = this.CommandParameters;

            return CreateCream(arguments);

        }
        //Each Cream has name, brand, price, gender, scent
        private string CreateCream(IList<string> arguments)
        {
            string name = arguments[0];
            string brand = arguments[1];
            bool priceIsvalid = decimal.TryParse(arguments[2], out decimal price);
            if(!priceIsvalid)
            {
                throw new ArgumentException("Price is not valid.");
            }
            bool genderIsValid = Enum.TryParse(arguments[3], out GenderType gender);
            if (!genderIsValid)
            {
                throw new ArgumentException("Gender is not valid.");
            }
            bool scentIsValid = Enum.TryParse(arguments[4], out ScentType scent);
            if (!scentIsValid)
            {
                throw new ArgumentException("ScentType is not valid.");
            }


            if (this.Repository.ProductExists(arguments[0]))
            {
                throw new ArgumentException(string.Format($"Cream with name {arguments[0]} already exists!"));
            }

            this.Repository.CreateCream(name, brand, price, gender, scent);

            return $"Cream with name {name} was created!";

        }
    }
}

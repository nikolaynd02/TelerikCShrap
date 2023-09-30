using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;

using System;
using System.Collections.Generic;
using System.Globalization;

namespace CosmeticsShop.Commands
{
    public class CreateProduct : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateProduct(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 4)
            {
                throw new InvalidCommandException($"Command expects 4 parameters and you entered {parameters.Count} parameters");
            }
            string name = parameters[0];
            string brand = parameters[1];

            // TODO: Validate price format            
            if(!double.TryParse(parameters[2], out double price))
            {
                throw new InvalidPriceException($"Third parameter should be price (real number).");
            }
            if(price < 0)
            {
                throw new InvalidPriceException($"Price can not be negative.");
            }

            // TODO: Validate gender format
            if(!Enum.TryParse<GenderType>(parameters[3], true, out GenderType gender))
            {
                throw new InvalidGenderException("Forth parameter should be one of Men, Women or Unisex");
            }

            // TODO: Ensure product name is unique
            if (this.cosmeticsRepository.ProductExist(name))
            {
                throw new InvalidNameException($"First parameter is name and it should be unique.");
            }
            this.cosmeticsRepository.CreateProduct(name, brand, price, gender);

            return $"Product with name {name} was created!";
        }
    }
}

using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;

using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class ShowCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public ShowCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            //TODO: Validate parameters count
            if (parameters.Count != 1)
            {
                throw new InvalidCommandException($"Command expects 1 parameters and you entered {parameters.Count} parameters");
            }
            string categoryName = parameters[0];

            Category category = this.cosmeticsRepository.FindCategoryByName(categoryName);

            return category.Print();
        }
    }
}

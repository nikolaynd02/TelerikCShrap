using CosmeticsShop.Core;
using CosmeticsShop.Exceptions;
using System.Collections.Generic;

namespace CosmeticsShop.Commands
{
    public class CreateCategory : ICommand
    {
        private readonly CosmeticsRepository cosmeticsRepository;

        public CreateCategory(CosmeticsRepository productRepository)
        {
            this.cosmeticsRepository = productRepository;
        }

        public string Execute(List<string> parameters)
        {
            if (parameters.Count != 1)
            {
                throw new InvalidCommandException($"Command expects 1 parameters and you entered {parameters.Count} parameters");
            }
            string categoryName = parameters[0];

            
            this.cosmeticsRepository.CreateCategory(categoryName);

            return $"Category with name {categoryName} was created!";
        }
    }
}

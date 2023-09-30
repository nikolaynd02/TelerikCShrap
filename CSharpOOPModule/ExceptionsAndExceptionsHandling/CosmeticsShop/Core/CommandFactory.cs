using CosmeticsShop.Commands;
using CosmeticsShop.Exceptions;
using System;

namespace CosmeticsShop.Core
{
    public class CommandFactory
    {
        public ICommand CreateCommand(string commandTypeValue, CosmeticsRepository productRepository)
        {
            //try
            //{

                if(!Enum.TryParse(commandTypeValue, true, out CommandType commandType))
                {
                    throw new InvalidCommandException($"Command {commandTypeValue} is not supported.");
                }

                switch (commandType)
                {
                    case CommandType.CreateCategory:
                        return new CreateCategory(productRepository);
                    case CommandType.CreateProduct:
                        return new CreateProduct(productRepository);
                    case CommandType.AddProductToCategory:
                        return new AddProductToCategory(productRepository);
                    case CommandType.ShowCategory:
                        return new ShowCategory(productRepository);
                    default:                       
                        throw new InvalidCommandException($"Command {commandTypeValue} is not supported.");
                        
                }
            //}
            //catch (InvalidCommandException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

            //return null;
        }
    }
}

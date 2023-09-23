using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace Cosmetics.Models
{
    public class Toothpaste : Product, IToothpaste
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandManLength = 10;

        private List<string> ingredients;


        public Toothpaste(string name, string brand, decimal price, GenderType gender, string ingredients) : base(name, brand, price, gender)
        {
            if(ingredients == null)
            {
                throw new ArgumentNullException("Ingredients can not be null");
            }
            this.ingredients = ingredients.Split(", ").ToList(); 
        }


        public string Ingredients
        {
            get { return string.Join(", ",ingredients); }           
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"#{Name} {Brand}");
            output.AppendLine($" #Price: {Price}");
            output.AppendLine($" #Gender: {Gender}");
            output.AppendLine($" #Ingredients: {string.Join(", ", ingredients)}");
            output.AppendLine($" ===");
 
            return output.ToString();

        }
    }
}

using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models
{
    public abstract class Product : IProduct
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private decimal price;
        private GenderType gender;

        public Product(string name, string brand, decimal price, GenderType gender)
        {
            Name = name;
            Brand = brand;
            Price = price;
            Gender = gender;
        }


        public string Name
        {
            get { return name; }
            private set
            {
                ValidationHelper.ValidateStringLength(value, NameMinLength, NameMaxLength);
                name = value;
            }
        }

        public string Brand
        {
            get { return brand; }
            private set
            {
                ValidationHelper.ValidateStringLength(value, BrandMinLength, BrandMaxLength);
                brand = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                ValidationHelper.ValidateNonNegative(value, "Price");
                price = value;
            }
        }

        public GenderType Gender
        {
            get { return gender; }
            private set 
            {
                //Enum.TryParse(arguments[3], out GenderType gender);
                bool genderIsValid = Enum.TryParse(value.ToString(), out this.gender);
                if (!genderIsValid)
                {
                    throw new ArgumentException("Gender is not valid.");
                }
            }
        }

        public abstract string Print();
        //{
        //    StringBuilder output = new StringBuilder();

        //    output.AppendLine($"#{name} {brand}");
        //    output.AppendLine($" #Price: {price}");
        //    output.AppendLine($" #Gender: {gender}");
        //    output.AppendLine($" #Milliliters: {millilitres}");
        //    output.AppendLine($" #Usage: {usage}");
        //    output.AppendLine($" ===");

        //}
    }
}

using System;
using System.Text;

namespace Cosmetics.Models
{
    public class Product
    {
        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private string name;
        private string brand;
        private double price;
        private GenderType gender;


        // "Each product in the system has name, brand, price and gender."

        public Product(string name, string brand, double price, GenderType gender)
        {
            Name = name;
            Brand = brand;
            Price = price;
            this.gender = gender;
        }

        public double Price
        {
            get
            {
               return price;
            }
            set
            {
                if(value < 0)
                {
                    throw new ArgumentException("Price can not be negative");
                }
                price = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
               if(value.Length < NameMinLength || value.Length > NameMaxLength)
               {
                    throw new ArgumentException($"Name must have length between {NameMinLength} and {NameMaxLength}");
               }
               name = value;
            }
        }

        public string Brand
        {
            get
            {
                return brand;
            }
            set
            {
                if (value.Length < BrandMinLength || value.Length > BrandMaxLength)
                {
                    throw new ArgumentException($"Name must have length between {BrandMinLength} and {BrandMaxLength}");
                }
                brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return gender;
            }
        }

        public string Print()
        {
            // Format:
            // #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]
            StringBuilder output = new StringBuilder();
            output.AppendLine($" #{name} {brand}");
            output.AppendLine($" #Price: {price}");
            output.AppendLine($" #Gender: {gender}");

            return output.ToString();
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
    }
}
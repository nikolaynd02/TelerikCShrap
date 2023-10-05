
using Dealership.Models.Contracts;
using System;
using System.Text;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        public const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";

        private string category;

        public Motorcycle(string make, string model, decimal price, string category) : base(make, model, price, VehicleType.Motorcycle, (int)VehicleType.Motorcycle)
        {
            Category = category;
        }

        public string Category
        {
            get { return category; }
            private set
            {
                Validator.ValidateIntRange(value.Length, CategoryMinLength, CategoryMaxLength, InvalidCategoryError);
                category = value;
            }
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.Append(base.ToString());
            output.AppendLine($"  Category: {Category}");
            return output.ToString();
        }
    }
}

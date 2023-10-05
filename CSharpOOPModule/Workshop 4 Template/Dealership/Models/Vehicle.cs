using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle 
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;
        public const string InvalidMakeError = "Make must be between 2 and 15 characters long!";
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const string InvalidModelError = "Model must be between 1 and 15 characters long!";
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidPriceError = "Price must be between 0.0 and 1000000.0!";

        private string make;
        private string model;
        private VehicleType type;
        private int wheels;
        private decimal price;
        private IList<IComment> comments;

        public Vehicle(string make, string model, decimal price, VehicleType type, int wheels)
        {
            Make = make;
            Model = model;
            Price = price;
            Type = type;
            Wheels = wheels;
            comments = new List<IComment>();
        }

        public string Make
        {
            get { return make; }            
            private set 
            {
                Validator.ValidateIntRange(value.Length, MakeMinLength, MakeMaxLength, InvalidMakeError);
                make = value; 
            }
        }

        public string Model
        {
            get { return model; }
            private set
            {
                Validator.ValidateIntRange(value.Length, ModelMinLength, ModelMaxLength, InvalidModelError);
                model = value;
            }
        }

        public VehicleType Type
        {
            get { return type; }
            private set
            {
                type = value;
            }
        }

        public int Wheels
        {
            get { return wheels; }
            private set
            {
                wheels = value;
            }
        }

        public decimal Price
        {
            get { return price; }
            private set
            {
                Validator.ValidateDecimalRange(value, MinPrice, MaxPrice, InvalidPriceError);
                price = value;
            }
        }

        public IList<IComment> Comments
        {
            get { return new List<IComment>(this.comments); }
        }

        public void AddComment(IComment comment)
        {
            if(comments == null)
            {
                throw new ArgumentNullException("Comment can not be null.");
            }
            //if (comments.Contains(comment))
            //{
            //    throw new ArgumentException("Comment already exists.");
            //}
            comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            if(comment == null)
            {
                throw new ArgumentNullException("Comment for removal can not be null");
            }
            comments.Remove(comment);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($". {Type.ToString()}:");
            output.AppendLine($"  Make: {Make}");
            output.AppendLine($"  Model: {Model}");
            output.AppendLine($"  Wheels: {Wheels}");
            output.AppendLine($"  Price: ${string.Format($"{Price:G29}")}");
            return output.ToString();
        }
    }
}

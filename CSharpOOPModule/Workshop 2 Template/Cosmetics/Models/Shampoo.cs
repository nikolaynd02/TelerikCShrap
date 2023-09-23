using Cosmetics.Helpers;
using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Reflection;
using System.Text;

namespace Cosmetics.Models
{
    public class Shampoo : Product, IShampoo
    {
        private const int NameMinLength = 3;
        private const int NameMaxLength = 10;
        private const int BrandMinLength = 2;
        private const int BrandMaxLength = 10;

        private int millilitres;
        private UsageType usage;

        public Shampoo(string name, string brand, decimal price, GenderType gender, int millilitres, UsageType usage) : base(name, brand, price, gender)
        {           
            Millilitres = millilitres;
            Usage = usage;
        }
        

        public int Millilitres
        {
            get { return millilitres; }
            set
            {
                ValidationHelper.ValidateNonNegative(value, "Millilitres");
                millilitres = value;
            }
        }

        //public GenderType Gender
        //{
        //    get { return gender; }
        //    private set
        //    {
        //        //Enum.TryParse(arguments[3], out GenderType gender);
        //        bool genderIsValid = Enum.TryParse(value.ToString(), out this.gender);
        //        if (!genderIsValid)
        //        {
        //            throw new ArgumentException("Gender is not valid.");
        //        }
        //    }
        //}

        public UsageType Usage
        {
            get { return usage; }
            private set 
            {
                bool usageIsValid = Enum.TryParse(value.ToString(), out this.usage);
                if (!usageIsValid)
                {
                    throw new ArgumentException("UsageType is not valid.");
                }
            }
        }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"#{Name} {Brand}");
            output.AppendLine($" #Price: {Price}");
            output.AppendLine($" #Gender: {Gender}");
            output.AppendLine($" #Milliliters: {millilitres}");
            output.AppendLine($" #Usage: {usage}");
            output.AppendLine($" ===");

            return output.ToString();

        }
    }
}

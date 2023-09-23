using Cosmetics.Models.Contracts;
using Cosmetics.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cosmetics.Models
{
    public class Cream : Product, ICream
    {
        private ScentType scent;
        public Cream(string name, string brand, decimal price, GenderType gender, ScentType scent) : base(name, brand, price, gender)
        {
            this.scent = scent;            
        }

        public ScentType Scent { get => this.scent; }

        public override string Print()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"#{Name} {Brand}");
            output.AppendLine($" #Price: {Price}");
            output.AppendLine($" #Gender: {Gender}");
            output.AppendLine($" #Scent: {Scent}");
            output.AppendLine($" ===");

            return output.ToString();
        }

    }
}

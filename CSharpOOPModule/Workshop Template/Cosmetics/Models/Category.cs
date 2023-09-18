using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;

        private string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            if(name.Length < NameMinLength || name.Length > NameMaxLength)
            {
                throw new ArgumentException($"Name must have length between {NameMinLength} and {NameMaxLength}");
            }

            products = new List<Product>();
            this.name = name;
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                if (value.Length < NameMinLength || value.Length > NameMaxLength)
                {
                    throw new ArgumentException($"Name must have length between {NameMinLength} and {NameMaxLength}");
                }

                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                //Chech later, might not be the proper way. The fiald is readonly.
                //var output = new List<Product>();
                //foreach(var product in products)
                //{
                //    output.Add(product);
                //}
                return new List<Product>(this.Products);
            }
        }

        public void AddProduct(Product product)
        {
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            int index = products.IndexOf(product);
            if(index == -1)
            {
                throw new ArgumentException("Product is not in list of products");
            }
            products.RemoveAt(index);
        }

        public string Print()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"#Category: {name}");
            foreach(Product product in products)
            {
                output.AppendLine(product.Print());
                output.AppendLine(" ===");
            }

            if(products.Count == 0)
            {
                output.AppendLine($" #No products in this category.");
            }

            return output.ToString();
        }
    }
}


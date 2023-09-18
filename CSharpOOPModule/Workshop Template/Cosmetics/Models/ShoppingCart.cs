using System;
using System.Collections.Generic;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            products = new List<Product>();
        }

        public List<Product> Products
        {
            get
            {
                //Check encapsulation
                return new List<Product>(this.products);
            }
        }

        public void AddProduct(Product product)
        {
            if(products == null)
            {
                throw new ArgumentNullException("Product can not be null.");
            }
            products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (product == null)
            {
                throw new ArgumentNullException("Product can not be null.");
            }
            if(products.Count == 0)
            {
                throw new ArgumentException("No products in cart.");
            }
            products.Remove(product);
        }

        public bool ContainsProduct(Product product)
        {
            if (products == null)
            {
                throw new ArgumentNullException("Product can not be null.");
            }

            int index = products.IndexOf(product);
            if(index == -1)
            {
                return false;
            }
            return true;
        }

        public double TotalPrice()
        {
            double total = 0;
            foreach(Product product in products)
            {
                total += product.Price;
            }

            return total;
        }
    }
}

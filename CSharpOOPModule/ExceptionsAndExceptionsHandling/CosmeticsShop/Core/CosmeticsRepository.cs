using CosmeticsShop.Exceptions;
using CosmeticsShop.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CosmeticsShop.Core
{
    public class CosmeticsRepository
    {
        private readonly List<Category> categories;
        private readonly List<Product> products;

        public CosmeticsRepository()
        {
            this.categories = new List<Category>();
            this.products = new List<Product>();
        }

        public List<Category> Categories
        {
            get
            {
                return this.categories;
            }
        }

        public List<Product> Products
        {
            get
            {
                return this.products;
            }
        }

        public void CreateCategory(string categoryName)
        {
            //try
            //{

                if(categories.Any(c => c.Name == categoryName))
                {
                    throw new InvalidNameException($"Category {categoryName} already exists");
                }

                this.categories.Add(new Category(categoryName));
            //}
            //catch(InvalidNameException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}

        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {          
            //try
            //{
                if (products.Any(p => p.Name == name))
                {
                    throw new InvalidNameException($"Product {name} already exists");
                }

                this.products.Add(new Product(name, brand, price, gender));
            //}
            //catch (InvalidNameException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
        }

        public bool CategoryExist(string name)
        {
            foreach (var category in this.categories)
            {
                if (category.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public Category FindCategoryByName(string name)
        {
            //try
            //{
                if (!CategoryExist(name))
                {
                    throw new InvalidNameException($"Category {name} does not exist.");
                }
                foreach (var category in this.categories)
                {
                    if (category.Name == name)
                    {
                        return category;
                    }
                }

            //}
            //catch(InvalidNameException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            
            return null;
        }

        public bool ProductExist(string name)
        {
            foreach (var product in this.products)
            {
                if (product.Name == name)
                {
                    return true;
                }
            }

            return false;
        }

        public Product FindProductByName(string name)
        {
            //try
            //{
                if (!ProductExist(name))
                {
                    throw new InvalidNameException($"Product {name} does not exist.");
                }

                foreach (var product in this.products)
                {
                    if (product.Name == name)
                    {
                        return product;
                    }
                }

            //}
            //catch(InvalidNameException ex)
            //{
            //    Console.WriteLine(ex.Message);
            //}
            
            return null;
        }
    }
}

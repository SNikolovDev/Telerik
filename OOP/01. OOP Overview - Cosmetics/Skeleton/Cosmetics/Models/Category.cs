using Cosmetics.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cosmetics.Models
{
    public class Category
    {
        //The same product can be added to a category more than once.

        private string name;
        List<Product> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<Product>();
        }

        public string Name
        {
            get => this.name;
            set
            {
                Helpers.ValidationHelpers.ValidateStringLength(value, Constants.CATEGORY_MIN_LENGTH, Constants.CATEGORY_MAX_LENGTH,
                    "Name length should be between 2 and 15 symbols!");

                this.name = value;
            }
        }

        public List<Product> Products
        {
            get => this.products;
        }

        public void AddProduct(Product product)
        {
            //The same product can be added to the shopping cart more than once.

            this.Products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            if (!this.Products.Contains(product))
            {
                throw new ArgumentException("Product is not found!");
            }

            this.Products.Remove(product);
        }

        public string Print()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var product in this.Products.OrderBy(p => p.Name).ThenByDescending(p => p.Price))
            {
                sb.AppendLine($"#Category: {this.Name}");
                sb.AppendLine(product.Print());
            }

            return sb.ToString().TrimEnd();
        }
    }
}


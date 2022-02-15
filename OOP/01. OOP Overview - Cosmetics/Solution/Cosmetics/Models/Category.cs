using System;
using System.Collections.Generic;
using System.Text;
using Cosmetics.Helpers;

namespace Cosmetics.Models
{
    public class Category
    {
        public const int NameMinLength = 2;
        public const int NameMaxLength = 15;
        public const string NameErrorMessage = "Name should be between {0} and {1} symbols.";

        private string name;
        private readonly List<Product> products;

        public Category(string name)
        {
            this.Name = name;
            this.products = new List<Product>();
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                string errorMessage = string.Format(NameErrorMessage, NameMinLength, NameMaxLength);
                ValidationHelpers.ValidateIntRange(NameMinLength, NameMaxLength, value.Length, errorMessage);
                this.name = value;
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            this.products.Remove(product);
        }

        public string Print()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine(string.Format($"#Category: {this.name}"));

            if (this.products.Count == 0)
            {
                result.AppendLine(" #No products in this category");
            }
            else
            {
                foreach (Product product in this.products)
                {
                    result.AppendLine(product.Print());
                    result.AppendLine(" ===");
                }
            }

            return result.ToString().Trim();
        }
    }
}
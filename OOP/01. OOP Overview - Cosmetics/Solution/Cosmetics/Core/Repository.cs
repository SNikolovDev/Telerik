using Cosmetics.Core.Contracts;
using Cosmetics.Models;
using System;
using System.Collections.Generic;

namespace Cosmetics.Core
{
    public class Repository : IRepository
    {
        private const string ProductDoesNotExist = "Product {0} does not exist!";
        private const string CategoryDoesNotExist = "Category {0} does not exist!";

        private readonly List<Product> products;
        private readonly List<Category> categories;
        private readonly ShoppingCart shoppingCart;

        public Repository()
        {
            this.products = new List<Product>();
            this.categories = new List<Category>();

            this.shoppingCart = new ShoppingCart();
        }

        public ShoppingCart ShoppingCart
        {
            get
            {
                return this.shoppingCart;
            }
        }

        public List<Category> Categories
        {
            get
            {
                return new List<Category>(this.categories);
            }
        }

        public List<Product> Products
        {
            get
            {
                return new List<Product>(this.products);
            }
        }

        public Product FindProductByName(string productName)
        {
            foreach (Product product in this.Products)
            {
                if (product.Name == productName)
                {
                    return product;
                }
            }

            throw new ArgumentException(string.Format(ProductDoesNotExist, productName));
        }

        public Category FindCategoryByName(string categoryName)
        {
            foreach (Category category in this.Categories)
            {
                if (category.Name == categoryName)
                {
                    return category;
                }
            }

            throw new ArgumentException(string.Format(CategoryDoesNotExist, categoryName));
        }

        public void CreateCategory(string categoryName)
        {
            this.categories.Add(new Category(categoryName));
        }

        public void CreateProduct(string name, string brand, double price, GenderType gender)
        {
            this.products.Add(new Product(name, brand, price, gender));
        }

        public bool CategoryExist(string categoryName)
        {
            bool exists = false;

            foreach (Category category in this.Categories)
            {
                if (category.Name == categoryName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }

        public bool ProductExist(string productName)
        {
            bool exists = false;

            foreach (Product product in this.Products)
            {
                if (product.Name == productName)
                {
                    exists = true;
                    break;
                }
            }

            return exists;
        }
    }
}

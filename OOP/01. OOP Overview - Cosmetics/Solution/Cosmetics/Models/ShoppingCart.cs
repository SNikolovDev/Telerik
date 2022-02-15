using System;
using System.Collections.Generic;

namespace Cosmetics.Models
{
    public class ShoppingCart
    {
        private readonly List<Product> products;

        public ShoppingCart()
        {
            this.products = new List<Product>();
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

        public bool ContainsProduct(Product product)
        {
            return this.products.Contains(product);
        }

        public double TotalPrice()
        {
            double totalPrice = 0;

            foreach (Product product in products)
            {
                totalPrice += product.Price;
            }

            return totalPrice;
        }
    }
}

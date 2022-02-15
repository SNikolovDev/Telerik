using System.Linq;
using System.Collections.Generic;
using Cosmetics.Core;
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
            get => this.products;
        }

        //Adding the same product more than once is allowed.
        public void AddProduct(Product product)
        {
            this.products.Add(product);
        }

        //Do not check if the product exists, when removing it from the shopping cart.
        public void RemoveProduct(Product product)
        {
            this.products.Remove(product);
        }

        public bool ContainsProduct(Product product)
        {
            if (this.Products.Contains(product))
            {
                return true;
            }

            return false;
        }

        public double TotalPrice()
        {
            return this.Products.Sum(p => p.Price);
        }
    }
}

using System;
using System.Text;
using Cosmetics.Helpers;

namespace Cosmetics.Models
{
    public class Product
    {
        // "Each product in the system has name, brand, price and gender."

        private string name;
        private string brand;
        private double price;
        private GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Name = name;
            this.Brand = brand;
            this.Price = price;
            this.gender = gender;
        }

        public double Price
        {
            get => this.price;
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Price must be a positive number!");
                }

                this.price = value;
            }
        }

        public string Name
        {
            get => this.name;
            set
            {
                Helpers.ValidationHelpers.ValidateStringLength(value, Constants.PRODUCT_MIN_LENGTH, Constants.PRODUCT_MAX_LENGTH,
                    "Product name should be between 3 and 10 symbols!");

                this.name = value;
            }

        }

        public string Brand
        {
            get => this.brand;
            set
            {
                Helpers.ValidationHelpers.ValidateStringLength(value, Constants.BRAND_MIN_LENGTH, Constants.BRAND_MAX_LENGTH,
                     "Brand name should be between 2 and 10 symbols!");

                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get => this.gender;
        }

        public string Print()
        {
            // Format:
            //" #[Name] [Brand]
            // #Price: [Price]
            // #Gender: [Gender]

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" #Price: {this.Price}");
            sb.AppendLine($" #Gender {this.Gender}");
            sb.AppendLine("===");

            return sb.ToString().TrimEnd();
        }

        public override bool Equals(object p)
        {
            if (p == null || !(p is Product))
            {
                return false;
            }

            if (this == p)
            {
                return true;
            }

            Product otherProduct = (Product)p;

            return this.Price == otherProduct.Price
                    && this.Name == otherProduct.Name
                    && this.Brand == otherProduct.Brand
                    && this.Gender == otherProduct.Gender;
        }
    }
}
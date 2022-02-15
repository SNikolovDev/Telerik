using System;
using System.Text;
using Cosmetics.Helpers;

namespace Cosmetics.Models
{
    public class Product
    {
        public const string PriceErrorMessage = "Price should not be negative.";
        public const string NameErrorMessage = "Name should be between {0} and {1} symbols.";
        public const string BrandErrorMessage = "Brand should be between {0} and {1} symbols.";

        public const int NameMinLength = 3;
        public const int NameMaxLength = 10;
        public const int BrandMinLength = 2;
        public const int BrandMaxLength = 10;

        private double price;
        private string name;
        private string brand;
        private readonly GenderType gender;

        public Product(string name, string brand, double price, GenderType gender)
        {
            this.Price = price;
            this.Name = name;
            this.Brand = brand;
            this.gender = gender;
        }

        public double Price
        {
            get
            {
                return this.price;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentException(PriceErrorMessage);
                }
                this.price = value;
            }
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

        public string Brand
        {
            get
            {
                return this.brand;
            }
            set
            {
                string errorMessage = string.Format(BrandErrorMessage, BrandMinLength, BrandMaxLength);
                ValidationHelpers.ValidateIntRange(BrandMinLength, BrandMaxLength, value.Length, errorMessage);
                this.brand = value;
            }
        }

        public GenderType Gender
        {
            get
            {
                return this.gender;
            }
        }

        public string Print()
        {
            var sb = new StringBuilder();
            sb.AppendLine($" #{this.Name} {this.Brand}");
            sb.AppendLine($" #Price: ${this.Price:0.##}");
            sb.AppendLine($" #Gender: {this.Gender}");
            return sb.ToString().Trim();
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
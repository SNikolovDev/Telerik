using Dealership.Models.Contracts;

using System.Text;
using System.Collections.Generic;
using System.Globalization;

namespace Dealership.Models
{
    public abstract class Vehicle : IVehicle
    {
        public const int MakeMinLength = 2;
        public const int MakeMaxLength = 15;
        public const string InvalidMakeError = "Make must be between 2 and 15 characters long!";
        public const int ModelMinLength = 1;
        public const int ModelMaxLength = 15;
        public const string InvalidModelError = "Model must be between 1 and 15 characters long!";
        public const decimal MinPrice = 0.0m;
        public const decimal MaxPrice = 1000000.0m;
        public const string InvalidPriceError = "Price must be between 0.0 and 1000000.0!";

        private string make;
        private string model;
        private decimal price;
        private readonly IList<IComment> comments;

        public Vehicle(string make, string model, decimal price, VehicleType type)
        {
            this.Make = make;
            this.Model = model;
            this.Price = price;
            this.comments = new List<IComment>();
        }

        public string Make
        {
            get => this.make;
            private set
            {
                Validator.ValidateIntRange(value.Length, MakeMinLength, MakeMaxLength, InvalidMakeError);

                this.make = value;
            }
        }

        public string Model
        {
            get => this.model;
            private set
            {
                Validator.ValidateIntRange(value.Length, ModelMinLength, ModelMaxLength, InvalidModelError);

                this.model = value;
            }
        }
        public abstract VehicleType Type { get; }
        public abstract int Wheels { get; }


        public decimal Price
        {
            get => this.price;
            private set
            {
                Validator.ValidateDecimalRange(value, MinPrice, MaxPrice, InvalidPriceError);

                this.price = value;
            }
        }
        public IList<IComment> Comments => new List<IComment>(this.comments);

        public void AddComment(IComment comment)
        {
            this.comments.Add(comment);
        }

        public void RemoveComment(IComment comment)
        {
            this.comments.Remove(comment);
        }

        protected abstract string GetVehicleType();


        public string PrintComments()
        {
            StringBuilder sb = new StringBuilder();

            if (this.Comments.Count > 0)
            {
                sb.AppendLine("    --COMMENTS--");
                foreach (var comment in this.Comments)
                {
                    sb.AppendLine("    ----------");
                    sb.AppendLine($"    {comment.Content}");
                    sb.AppendLine($"      User: {comment.Author}");
                    sb.AppendLine("    ----------");
                }

                sb.AppendLine("    --COMMENTS--");
            }
            else
            {
                sb.AppendLine("    --NO COMMENTS--");
            }

            return sb.ToString().TrimEnd();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($" {GetVehicleType()}:");
            sb.AppendLine($"  Make: {this.Make}");
            sb.AppendLine($"  Model: {this.Model}");
            sb.AppendLine($"  Wheels: {this.Wheels}");
            sb.AppendLine($"  Price: ${RemoveTrailingZerosFromDouble(this.Price)}");

            return sb.ToString().TrimEnd();
        }

        public static string RemoveTrailingZerosFromDouble(decimal value)
        {
            return value.ToString("G29", CultureInfo.InvariantCulture);
        }
    }
}

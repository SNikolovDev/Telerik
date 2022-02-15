using Dealership.Models.Contracts;

using System.Text;

namespace Dealership.Models
{
    public class Motorcycle : Vehicle, IMotorcycle
    {
        public const int CategoryMinLength = 3;
        public const int CategoryMaxLength = 10;
        public const string InvalidCategoryError = "Category must be between 3 and 10 characters long!";

        private string category;

        public Motorcycle(string make, string model, decimal price, string category)
            : base(make, model, price, VehicleType.Motorcycle)
        {
            this.Category = category;
        }

        public string Category
        {
            get => this.category;
            set
            {
                Validator.ValidateIntRange(value.Length, CategoryMinLength, CategoryMaxLength, InvalidCategoryError);

                this.category = value;
            }
        }

        public override VehicleType Type => VehicleType.Motorcycle;

        public override int Wheels => (int)this.Type;

        protected override string GetVehicleType()
        {
            return "Motorcycle";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"  Category: {this.Category}");
            sb.Append(base.PrintComments());

            return sb.ToString().TrimEnd();
        }
    }
}

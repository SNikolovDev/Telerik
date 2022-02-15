using Dealership.Models.Contracts;
using System.Linq;
using System.Text;

namespace Dealership.Models
{
    public class Truck : Vehicle, ITruck
    {
        public const int MinCapacity = 1;
        public const int MaxCapacity = 100;
        public const string InvalidCapacityError = "Weight capacity must be between 1 and 100!";

        private int weightCapacity;

        public Truck(string make, string model, decimal price, int weightCapacity)
            : base(make, model, price, VehicleType.Truck)
        {
            this.WeightCapacity = weightCapacity;
        }

        public int WeightCapacity
        {
            get => this.weightCapacity;
            set
            {
                Validator.ValidateIntRange(value, MinCapacity, MaxCapacity, InvalidCapacityError);

                this.weightCapacity = value;
            }
        }

        public override VehicleType Type => VehicleType.Truck;

        public override int Wheels => (int)this.Type;

        protected override string GetVehicleType()
        {
            return "Truck";
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"  Weight Capacity: {this.WeightCapacity}t");
            sb.Append(base.PrintComments());

            return sb.ToString().TrimEnd();
        }
    }
}

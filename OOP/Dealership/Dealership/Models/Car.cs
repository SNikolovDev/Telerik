using Dealership.Models.Contracts;

using System.Text;

namespace Dealership.Models
{
    public class Car : Vehicle, ICar
    {
        public const int MinSeats = 1;
        public const int MaxSeats = 10;
        public const string InvalidSeatsError = "Seats must be between 1 and 10!";

        private int seats;

        public Car(string make, string model, decimal price, int seats)
            : base(make, model, price, VehicleType.Car)
        {
            this.Seats = seats;
        }

        public int Seats
        {
            get => this.seats;
            private set
            {
                Validator.ValidateIntRange(value, MinSeats, MaxSeats, InvalidSeatsError);

                this.seats = value;
            }
        }
        public override VehicleType Type => VehicleType.Car;

        public override int Wheels => (int)this.Type;

        protected override string GetVehicleType()
        {
            return "Car";
        }       

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"  Seats: {this.Seats}");
            sb.Append(base.PrintComments());           

            return sb.ToString().TrimEnd();
        }
    }
}

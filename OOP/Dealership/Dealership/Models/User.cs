using Dealership.Exceptions;
using Dealership.Models.Contracts;

using System.Text;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Collections;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidNameError = "name must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than {0} vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        IList<IVehicle> vehicles;
        private Role role;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            this.vehicles = new List<IVehicle>();
            this.Username = username;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Password = password;
            this.role = role;
        }

        public string Username
        {
            get => this.username;
            set
            {
                Validator.ValidateSymbols(value, UsernamePattern, InvalidUsernameFormatError);
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidUsernameLengthError);

                this.username = value;
            }
        }

        public string FirstName
        {
            get => this.firstName;
            set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, "First" + InvalidNameError);

                this.firstName = value;
            }
        }

        public string LastName
        {
            get => this.lastName;
            set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, "Last" + InvalidNameError);

                this.lastName = value;
            }
        }

        public string Password
        {
            get => this.password;
            set
            {
                Validator.ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);
                Validator.ValidateIntRange(value.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
                ;
                this.password = value;
            }
        }

        public Role Role
        {
            get
            {
                return this.role;
            }
        }

        public IList<IVehicle> Vehicles => new List<IVehicle>(this.vehicles);

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            vehicleToAddComment.AddComment(commentToAdd);
        }

        public void AddVehicle(IVehicle vehicle)
        {
            if (this.role.ToString() == Role.Admin.ToString())
            {
                throw new ArgumentException(AdminCannotAddVehicles);
            }
            else if (this.role.ToString() == Role.Normal.ToString() && this.Vehicles.Count == 5)
            {
                throw new ArgumentException(string.Format(NotAnVipUserVehiclesAdd, MaxVehiclesToAdd));
            }

            this.vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"--USER {this.Username}--");
            int id = 1;

            foreach (var vehicle in this.vehicles)
            {
                sb.AppendLine($"{id}.{vehicle.ToString()}");
                id++;
            }

            return this.Vehicles.Count > 0 ? sb.ToString().TrimEnd() : $"--USER {this.Username}--" + Environment.NewLine + NoVehiclesHeader;
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if (commentToRemove.Author != this.Username)
            {
                throw new ArgumentException("You are not the author of the comment you are trying to remove!");
            }

            vehicleToRemoveComment.RemoveComment(commentToRemove);
        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            this.vehicles.Remove(vehicle);
        }
    }
}

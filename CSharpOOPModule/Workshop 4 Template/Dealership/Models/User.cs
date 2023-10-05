
using Dealership.Exceptions;
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace Dealership.Models
{
    public class User : IUser
    {
        private const string UsernamePattern = "^[A-Za-z0-9]+$";
        private const string InvalidUsernameFormatError = "Username contains invalid symbols!";
        private const string InvalidUsernameLengthError = "Username must be between 2 and 20 characters long!";

        private const int NameMinLength = 2;
        private const int NameMaxLength = 20;
        private const string InvalidFirstNameError = "Firstname must be between 2 and 20 characters long!";
        private const string InvalidlLastNameError = "Lastname must be between 2 and 20 characters long!";

        private const int PasswordMinLength = 5;
        private const int PasswordMaxLength = 30;
        private const string PasswordPattern = "^[A-Za-z0-9@*_-]+$";
        private const string InvalidPasswordFormatError = "Username contains invalid symbols!";
        private const string InvalidPasswordLengthError = "Password must be between 5 and 30 characters long!";

        private const int MaxVehiclesToAdd = 5;

        private const string NotAnVipUserVehiclesAdd = "You are not VIP and cannot add more than 5 vehicles!";
        private const string AdminCannotAddVehicles = "You are an admin and therefore cannot add vehicles!";
        private const string YouAreNotTheAuthor = "You are not the author of the comment you are trying to remove!";
        private const string NoVehiclesHeader = "--NO VEHICLES--";

        private string username;
        private string firstName;
        private string lastName;
        private string password;
        private Role role;
        private IList<IVehicle> vehicles;

        public User(string username, string firstName, string lastName, string password, Role role)
        {
            Username = username;
            FirstName = firstName;
            LastName = lastName;
            Password = password;
            Role = role;
            vehicles = new List<IVehicle>();
        }

        public string Username
        {
            get { return username; }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidUsernameLengthError);
                Validator.ValidateSymbols(value, UsernamePattern, InvalidUsernameFormatError);
                username = value;
            }
        }

        public string FirstName
        {
            get { return firstName; }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidFirstNameError);
                
                firstName = value;
            }
        }

        public string LastName
        {
            get { return lastName; }
            private set
            {
                Validator.ValidateIntRange(value.Length, NameMinLength, NameMaxLength, InvalidlLastNameError);
                lastName = value;
            }
        }

        public string Password
        {
            get { return password; }
            private set
            {
                Validator.ValidateIntRange(value.Length, PasswordMinLength, PasswordMaxLength, InvalidPasswordLengthError);
                Validator.ValidateSymbols(value, PasswordPattern, InvalidPasswordFormatError);
                password = value;
            }
        }

        public Role Role
        {
            get { return role; }
            private set { role = value; }
        }

        public IList<IVehicle> Vehicles
        {
            get { return new List<IVehicle>(vehicles); }
        }

        public void AddComment(IComment commentToAdd, IVehicle vehicleToAddComment)
        {
            if (commentToAdd == null)
            {
                throw new ArgumentNullException("Comment can not be null.");
            }
            if (vehicleToAddComment == null)
            {
                throw new ArgumentNullException("Vehicle to add can not be null.");
            }
            //if (vehicleToAddComment.Comments.Contains(commentToAdd))
            //{
            //    throw new ArgumentException("Comment already exists for this vehicle.");
            //}

            vehicleToAddComment.AddComment(commentToAdd);

        }

        public void AddVehicle(IVehicle vehicle)
        {
            if(role == Role.Admin)
            {
                throw new AuthorizationException(AdminCannotAddVehicles);
            }
            if(vehicles.Count == MaxVehiclesToAdd && role != Role.VIP)
            {
                throw new AuthorizationException(NotAnVipUserVehiclesAdd);
            }

            if(vehicle == null)
            {
                throw new ArgumentNullException("Vehicle to add can not be null.");
            }
            //if (vehicles.Contains(vehicle))
            //{
            //    throw new AuthorizationException("");
            //}
            vehicles.Add(vehicle);
        }

        public string PrintVehicles()
        {
            StringBuilder output = new StringBuilder();

            output.AppendLine($"--USER {Username}--");

            if(vehicles.Count == 0)
            {
                output.AppendLine(NoVehiclesHeader);
                return output.ToString();
            }



            int vehicleCounter = 1;
            foreach(var vehicle in vehicles)
            {
                output.Append($"{vehicleCounter++}");
                output.Append(vehicle.ToString());

                if(vehicle.Comments.Count == 0)
                {
                    output.AppendLine("    --NO COMMENTS--");
                }
                else
                {
                    output.AppendLine("    --COMMENTS--");

                    foreach(var comment in vehicle.Comments)
                    {
                        output.AppendLine("    ----------");
                        output.AppendLine($"    {comment.Content}");
                        output.AppendLine($"      User: {comment.Author}");
                        output.AppendLine("    ----------");
                    }
                    output.AppendLine("    --COMMENTS--");
                }

            }

            return output.ToString();
        }

        public void RemoveComment(IComment commentToRemove, IVehicle vehicleToRemoveComment)
        {
            if(vehicleToRemoveComment == null)
            {
                throw new ArgumentNullException("Vehicle to remove comment from can not be null.");
            }
            if(commentToRemove == null)
            {
                throw new ArgumentNullException("Comment to remove can not be null.");
            }

            if(commentToRemove.Author != username)
            {
                throw new AuthorizationException(YouAreNotTheAuthor);
            }


            vehicleToRemoveComment.RemoveComment(commentToRemove);


        }

        public void RemoveVehicle(IVehicle vehicle)
        {
            if(vehicle == null)
            {
                throw new ArgumentNullException("Vehicle to remove can not be null.");
            }

            vehicles.Remove(vehicle);
        }

        public override string ToString()
        {
            StringBuilder output = new StringBuilder();
            output.AppendLine($"Username: {Username}, FullName: {FirstName} {LastName}, Role: {Role}");

            return output.ToString();
        }
    }
}

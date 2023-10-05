
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using Dealership.Models;
using Dealership.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand( IRepository repository)
            : base(repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if (RequireLogin)
            {
                throw new AuthorizationException("You are not an admin!");
            }
            return this.ShowUsers();
        }

        private string ShowUsers()
        {
            IList<IUser> users = this.Repository.Users;

            StringBuilder output = new StringBuilder();

            

            foreach(var user in users)
            {
                output.AppendLine(user.ToString());
            }


            return output.ToString();
        }
    }
}

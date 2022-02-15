
using Dealership.Core.Contracts;
using Dealership.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Dealership.Commands
{
    public class ShowUsersCommand : BaseCommand
    {
        public ShowUsersCommand(List<string> parameters, IRepository repository)
             : base(parameters, repository)
        {
        }

        protected override bool RequireLogin
        {
            get { return true; }
        }

        protected override string ExecuteCommand()
        {
            if (this.Repository.LoggedUser.Role != Models.Role.Admin)
            {
                throw new AuthorizationException("You are not an admin!");
            }

            StringBuilder sb = new StringBuilder();
            int id = 1;

            sb.AppendLine("--USERS--");
            foreach (var user in this.Repository.Users)
            {
                sb.AppendLine($"{id}. Username: {user.Username}, FullName: {user.FirstName} {user.LastName}, Role: {user.Role}");
                id++;
            }

            return sb.ToString().TrimEnd();
        }
    }
}

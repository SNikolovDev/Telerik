using Academy.Core.Contracts;
using Academy.Models.Enums;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateStudentCommand : BaseCommand
    {
        public CreateStudentCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 2)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string username = this.CommandParameters[0];
            Track track = this.ParseTrackParameter(this.CommandParameters[1], "track");

            if (this.Repository.UserExists(username))
            {
                throw new ArgumentException($"A user with the username {username} already exists!");
            }

            this.Repository.CreateStudent(username, track);

            return $"Student with ID {this.Repository.Students.Count - 1} was created.";
        }
    }
}

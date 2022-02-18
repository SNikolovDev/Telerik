using Academy.Core.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Adding
{
    public class AddStudentToSeasonCommand : BaseCommand
    {
        public AddStudentToSeasonCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 2)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 2, Received: {this.CommandParameters.Count}");
            }

            string studentUsername = this.CommandParameters[0];
            int seasonId = this.ParseIntParameter(this.CommandParameters[1], "seasonId");

            var student = this.Repository.GetStudentByUsername(studentUsername);
            var season = this.Repository.Seasons[seasonId];

            if (season.Students.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The Student {studentUsername} is already a part of Season {seasonId}!");
            }
            season.Students.Add(student);

            return $"Student {studentUsername} was added to Season {seasonId}.";
        }
    }
}

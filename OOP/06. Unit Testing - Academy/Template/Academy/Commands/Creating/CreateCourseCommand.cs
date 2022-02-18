using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateCourseCommand : BaseCommand
    {
        public CreateCourseCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 4)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 4, Received: {this.CommandParameters.Count}");
            }
            
            int seasonId = this.ParseIntParameter(this.CommandParameters[0], "seasonId");
            string name = this.CommandParameters[1];
            int lecturesPerWeek = this.ParseIntParameter(this.CommandParameters[2], "lecturesPerWeek");
            DateTime startingDate = this.ParseDateTimeParameter(this.CommandParameters[3], "startingDate");

            var season = this.Repository.Seasons[seasonId];
            var course = this.Repository.CreateCourse(name, lecturesPerWeek, startingDate, startingDate.AddDays(30));
            season.Courses.Add(course);

            return $"Course with ID {season.Courses.Count - 1} was created in Season {seasonId}.";
        }
    }
}

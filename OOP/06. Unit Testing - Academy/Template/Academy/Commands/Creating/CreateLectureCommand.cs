using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateLectureCommand : BaseCommand
    {
        public CreateLectureCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 5)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 5, Received: {this.CommandParameters.Count}");
            }

            int seasonId = this.ParseIntParameter(this.CommandParameters[0], "seasonId");
            int courseId = this.ParseIntParameter(this.CommandParameters[1], "courseId");
            string name = this.CommandParameters[2];
            DateTime date = this.ParseDateTimeParameter(this.CommandParameters[3], "date");
            string trainerUsername = this.CommandParameters[4];

            var course = this.Repository.GetCourse(seasonId, courseId);
            var trainer = this.Repository.GetTrainerByUsername(trainerUsername);
            var lecture = this.Repository.CreateLecture(name, date, trainer);
            course.Lectures.Add(lecture);

            return $"Lecture with ID {course.Lectures.Count - 1} was created in course {seasonId}.{course.Name}.";
        }
    }
}

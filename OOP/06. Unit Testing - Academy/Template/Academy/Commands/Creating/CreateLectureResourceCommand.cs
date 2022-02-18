using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Creating
{
    public class CreateLectureResourceCommand : BaseCommand
    {
        public CreateLectureResourceCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 6)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 6, Received: {this.CommandParameters.Count}");
            }

            int seasonId = this.ParseIntParameter(this.CommandParameters[0], "seasonId");
            int courseId = this.ParseIntParameter(this.CommandParameters[1], "courseId");
            int lectureId = this.ParseIntParameter(this.CommandParameters[2], "lectureId");
            string type = this.CommandParameters[3];
            string name = this.CommandParameters[4];
            string url = this.CommandParameters[5];

            var course = this.Repository.GetCourse(seasonId, courseId);
            var lecture = course.Lectures[lectureId];
            var lectureResource = this.Repository.CreateLectureResource(type, name, url);
            lecture.Resources.Add(lectureResource);

            return $"Lecture resource with ID {lecture.Resources.Count - 1} was created in Lecture {seasonId}.{course.Name}.{lecture.Name}.";
        }
    }
}

using Academy.Core.Contracts;

using System;
using System.Collections.Generic;

namespace Academy.Commands.Adding
{
    public class AddStudentToCourseCommand : BaseCommand
    {
        public AddStudentToCourseCommand(IList<string> commandParameters, IRepository repository)
            : base(commandParameters, repository)
        {
        }

        public override string Execute()
        {
            if (this.CommandParameters.Count < 4)
            {
                throw new ArgumentException($"Invalid number of arguments. Expected: 4, Received: {this.CommandParameters.Count}");
            }

            string studentUsername = this.CommandParameters[0];
            int seasonId = this.ParseIntParameter(this.CommandParameters[1], "seasonId");
            int courseId = this.ParseIntParameter(this.CommandParameters[2], "courseId");
            string form = this.CommandParameters[3];

            var student = this.Repository.GetStudentByUsername(studentUsername);
            var course = this.Repository.GetCourse(seasonId, courseId);

            switch (form.ToLower())
            {
                case "onsite":
                    course.OnsiteStudents.Add(student);
                    break;
                case "online":
                    course.OnlineStudents.Add(student);
                    break;
                default:
                    throw new ArgumentException($"Cannot add student to course {seasonId}.{course.Name}. Invalid course form {form}!");
            }

            return $"Student {studentUsername} was added to Course {seasonId}.{course.Name}.";
        }
    }
}

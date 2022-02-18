using Academy.Core.Contracts;

using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Commands.Creating
{
    public class CreateCourseResultCommand : BaseCommand
    {
        public CreateCourseResultCommand(IList<string> commandParameters, IRepository repository)
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
            float examPoints = this.ParseFloatParameter(this.CommandParameters[2], "examPoints");
            float coursePoints = this.ParseFloatParameter(this.CommandParameters[3], "coursePoints");
            string studentUsername = this.CommandParameters[4];

            var student = this.Repository.GetStudentByUsername(studentUsername);

            var course = this.Repository.GetCourse(seasonId, courseId);

            if (!course.OnsiteStudents.Any(x => x.Username.ToLower() == studentUsername.ToLower()) &&
                !course.OnlineStudents.Any(x => x.Username.ToLower() == studentUsername.ToLower()))
            {
                throw new ArgumentException($"The student {studentUsername} is not signed up for the course {seasonId}.{course.Name}!");
            }

            var courseResult = this.Repository.CreateCourseResult(course, examPoints, coursePoints);
            student.CourseResults.Add(courseResult);

            return $"Course result with ID {student.CourseResults.Count - 1} was created for Student {studentUsername}.";
        }
    }
}

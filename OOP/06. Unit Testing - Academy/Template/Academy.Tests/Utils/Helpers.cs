using Academy.Models;
using System;
using System.Collections.Generic;

namespace Academy.Tests.Utils
{
    internal static class Helpers
    {
        public static Course GetCourse()
        {
            return new Course("Alpha C#", 5, DateTime.Now, DateTime.Now.AddMonths(6));
        }

        public static Student GetStudent()
        {
            return new Student("BruceBanner", Models.Enums.Track.Frontend);
        }

        public static Lecture GetLecture()
        {
            Trainer traineer = new Trainer("Alice", new List<string>());

            return new Lecture("Unit Testing", DateTime.Now.AddDays(10), traineer);
        }
    }
}

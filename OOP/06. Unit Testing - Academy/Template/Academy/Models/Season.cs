using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Academy.Models
{
    public class Season : ISeason
    {
        private int startingYear;
        private int endingYear;

        public Season(int starting, int ending, Initiative initiative)
        {
            this.StartingYear = starting;
            this.EndingYear = ending;
            this.Initiative = initiative;

            this.Students = new List<IStudent>();
            this.Trainers = new List<ITrainer>();
            this.Courses = new List<ICourse>();
        }

        public int StartingYear
        {
            get
            {
                return this.startingYear;
            }
            set
            {
                if (value < 2016 || value > 2020)
                {
                    throw new ArgumentException("The season's starting year cannot be before 2016 or after 2020!");
                }

                this.startingYear = value;
            }
        }

        public int EndingYear
        {
            get
            {
                return this.endingYear;
            }
            set
            {
                if (value < 2016 || value > 2020)
                {
                    throw new ArgumentException("The season's ending year cannot be before 2016 or after 2020!");
                }

                this.endingYear = value;
            }
        }

        public Initiative Initiative { get; }

        public IList<IStudent> Students { get; }

        public IList<ITrainer> Trainers { get; }

        public IList<ICourse> Courses { get; }

        public string ListUsers()
        {
            var builder = new StringBuilder();

            if (this.Trainers.Any())
            {
                foreach (var trainer in this.Trainers)
                {
                    builder.AppendLine(trainer.ToString());
                }
            }

            if (this.Students.Any())
            {
                foreach (var student in this.Students)
                {
                    builder.AppendLine(student.ToString());
                }
            }

            if (builder.ToString().Equals(""))
            {
                return $"There are no users in this season!";
            }

            return builder.ToString().TrimEnd();
        }

        public string ListCourses()
        {
            var builder = new StringBuilder();

            if (this.Courses.Any())
            {
                foreach (var course in this.Courses)
                {
                    builder.AppendLine(course.ToString());
                }

                return builder.ToString().TrimEnd();
            }

            return $"There are no courses in this season!";
        }
    }
}

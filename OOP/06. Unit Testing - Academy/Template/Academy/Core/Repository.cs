using Academy.Core.Contracts;
using Academy.Models;
using Academy.Models.Contracts;
using Academy.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Academy.Core
{
    public class Repository : IRepository
    {
        private readonly IList<ISeason> seasons = new List<ISeason>();
        private readonly IList<IStudent> students = new List<IStudent>();
        private readonly IList<ITrainer> trainers = new List<ITrainer>();

        public IList<ISeason> Seasons
        {
            get
            {
                var copy = new List<ISeason>(this.seasons);
                return copy;
            }
        }

        public IList<IStudent> Students
        {
            get
            {
                var copy = new List<IStudent>(this.students);
                return copy;
            }
        }

        public IList<ITrainer> Trainers
        {
            get
            {
                var copy = new List<ITrainer>(this.trainers);
                return copy;
            }
        }

        public Repository()
        {
        }

        public IStudent GetStudentByUsername(string username)
        {
            var student = this.Students.Single(x => x.Username.ToLower() == username.ToLower());
            return student;
        }

        public ITrainer GetTrainerByUsername(string username)
        {
            var trainer = this.Trainers.Single(x => x.Username.ToLower() == username.ToLower());
            return trainer;
        }

        public bool UserExists(string username)
        {
            return this.Students.Any(x => x.Username.ToLower() == username.ToLower()) ||
                this.Trainers.Any(x => x.Username.ToLower() == username.ToLower());
        }

        public ICourse GetCourse(int seasonId, int courseId)
        {
            var course = this.Seasons[seasonId].Courses[courseId];
            return course;
        }

        public ISeason CreateSeason(int startingYear, int endingYear, Initiative initiative)
        {
            var season = new Season(startingYear, endingYear, initiative);
            this.seasons.Add(season);
            return season;
        }

        public IStudent CreateStudent(string username, Track track)
        {
            var student = new Student(username, track);
            this.students.Add(student);
            return student;
        }

        public ITrainer CreateTrainer(string username, IList<string> technologies)
        {
            var trainer = new Trainer(username, technologies);
            this.trainers.Add(trainer);
            return trainer;
        }

        public ICourse CreateCourse(string name, int lecturesPerWeek, DateTime startingDate, DateTime endingDate)
        {
            return new Course(name, lecturesPerWeek, startingDate, endingDate);
        }

        public ILecture CreateLecture(string name, DateTime date, ITrainer trainer)
        {
            return new Lecture(name, date, trainer);
        }

        public ILectureResource CreateLectureResource(string type, string name, string url)
        {
            var currentDate = DateTime.Now;

            switch (type)
            {
                case "video":
                    return new VideoResource(name, url, currentDate);
                case "presentation":
                    return new PresentationResource(name, url);
                case "demo":
                    return new DemoResource(name, url);
                case "homework":
                    return new HomeworkResource(name, url, currentDate.AddDays(7));
                default:
                    throw new ArgumentException("Invalid lecture resource type");
            }
        }

        public ICourseResult CreateCourseResult(ICourse course, float examPoints, float coursePoints)
        {
            return new CourseResult(course, examPoints, coursePoints);
        }
    }
}

using Academy.Models.Contracts;
using Academy.Models.Enums;

using System;
using System.Collections.Generic;

namespace Academy.Core.Contracts
{
    public interface IRepository
    {
        IList<ISeason> Seasons { get; }

        IList<IStudent> Students { get; }

        IList<ITrainer> Trainers { get; }

        IStudent GetStudentByUsername(string username);

        ITrainer GetTrainerByUsername(string username);

        bool UserExists(string username);

        ICourse GetCourse(int seasonId, int courseId);

        ISeason CreateSeason(int startingYear, int endingYear, Initiative initiative);

        IStudent CreateStudent(string username, Track track);

        ITrainer CreateTrainer(string username, IList<string> technologies);

        ICourse CreateCourse(string name, int lecturesPerWeek, DateTime startingDate, DateTime endingDate);

        ILecture CreateLecture(string name, DateTime date, ITrainer trainer);

        ILectureResource CreateLectureResource(string type, string name, string url);

        ICourseResult CreateCourseResult(ICourse course, float examPoints, float coursePoints);
    }
}

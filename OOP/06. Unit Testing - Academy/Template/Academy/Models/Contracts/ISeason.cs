using Academy.Models.Enums;
using System;
using System.Collections.Generic;

namespace Academy.Models.Contracts
{
    public interface ISeason
    {
        Initiative Initiative { get; }

        int StartingYear { get; set; }

        int EndingYear { get; set; }

        IList<IStudent> Students { get; }

        IList<ITrainer> Trainers { get; }

        IList<ICourse> Courses { get; }

        string ListUsers();

        string ListCourses();
    }
}

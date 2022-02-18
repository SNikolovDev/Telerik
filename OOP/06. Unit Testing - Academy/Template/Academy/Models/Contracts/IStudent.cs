using Academy.Models.Enums;
using System.Collections.Generic;

namespace Academy.Models.Contracts
{
    public interface IStudent : IUser
    {
        Track Track { get; }

        IList<ICourseResult> CourseResults { get; }
    }
}

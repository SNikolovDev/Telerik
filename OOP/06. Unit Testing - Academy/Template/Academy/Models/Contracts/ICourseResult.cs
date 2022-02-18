using Academy.Models.Enums;

namespace Academy.Models.Contracts
{
    public interface ICourseResult
    {
        ICourse Course { get; }

        float ExamPoints { get; }

        float CoursePoints { get; }

        Grade Grade { get; }
    }
}

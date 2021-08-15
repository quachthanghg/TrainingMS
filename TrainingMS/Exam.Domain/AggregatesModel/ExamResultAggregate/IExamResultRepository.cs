using System.Threading.Tasks;
using Exam.Domain.SeedWork;

namespace Exam.Domain.AggregatesModel.ExamResultAggregate
{
    public interface IExamResultRepository : IRepositoryBase<ExamResult>
    {
        Task<ExamResult> GetDetails(string userId, string examId);
    }
}

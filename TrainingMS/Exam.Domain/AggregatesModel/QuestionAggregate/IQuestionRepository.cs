using Exam.Common.SeedWork;
using Exam.Domain.SeedWork;
using System.Threading.Tasks;

namespace Exam.Domain.AggregatesModel.QuestionAggregate
{
    public interface IQuestionRepository : IRepositoryBase<Question>
    {
        Task<PagedList<Question>> GetQuestionsPagingAsync(string categoryId, string searchKeyword, int pageIndex, int pageSize);

        Task<Question> GetQuestionsByIdAsync(string id);
    }
}

using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.SeedWork;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface IQuestionService
    {
        Task<ApiResult<PagedList<QuestionDto>>> GetCategoriesPagingAsync(QuestionFilter auestionFilter);
        Task<ApiResult<QuestionDto>> GetQuestionByIdAsync(string id);
        Task<bool> CreateAsync(CreateQuestionRequest request);
        Task<bool> UpdateAsync(UpdateQuestionRequest request);
        Task<bool> DeleteAsync(string id);
    }
}

using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Queries.Questions
{
    public class GetQuestionsPagingQuery : IRequest<PagedList<QuestionDto>>
    {
        public string CategoryId { get; set; }
        public string SearchKeyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

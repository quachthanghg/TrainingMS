using Exam.Common.Dtos.Exam.Questions;
using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Queries.Questions
{
    public class GetQuestionByIdQuery : IRequest<ApiResult<QuestionDto>>
    {
        public GetQuestionByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}

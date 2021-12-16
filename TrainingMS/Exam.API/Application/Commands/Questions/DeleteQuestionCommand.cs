using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Commands.Questions
{
    public class DeleteQuestionCommand : IRequest<ApiResult<bool>>
    {
        public DeleteQuestionCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}

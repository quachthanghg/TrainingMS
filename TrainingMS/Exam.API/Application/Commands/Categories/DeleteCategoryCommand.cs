using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Commands.Categories
{
    public class DeleteCategoryCommand : IRequest<ApiResult<bool>>
    {
        public DeleteCategoryCommand(string id)
        {
            Id = id;
        }
        public string Id { get; set; }
    }
}

using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Commands.Categories
{
    public class UpdateCategoryCommand : IRequest<ApiResult<bool>>
    {
        public string Id { get; set; }
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}

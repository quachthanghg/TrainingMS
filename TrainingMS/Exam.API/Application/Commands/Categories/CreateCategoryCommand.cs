using Exam.Common.Dtos.Exam.Categories;
using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Commands.Categories
{
    public class CreateCategoryCommand : IRequest<ApiResult<CategoryDto>>
    {
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}

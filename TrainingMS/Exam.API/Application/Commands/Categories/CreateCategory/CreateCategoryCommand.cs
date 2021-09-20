using Exam.Common.Dtos.Exam.Categories;
using MediatR;

namespace Exam.API.Application.Commands.Categories.CreateCategory
{
    public class CreateCategoryCommand : IRequest<CategoryDto>
    {
        public string Name { set; get; }
        public string UrlPath { get; set; }
    }
}

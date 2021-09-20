using Exam.Common.Dtos.Exam.Categories;
using MediatR;

namespace Exam.API.Application.Queries.Categories.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDto>
    {
        public GetCategoryByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}

using Exam.Common.Dtos.Exam.Categories;
using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Queries.Categories
{
    public class GetCategoryByIdQuery : IRequest<ApiResult<CategoryDto>>
    {
        public GetCategoryByIdQuery(string id)
        {
            Id = id;
        }
        public string Id { set; get; }
    }
}

using Exam.Common.Dtos.Exam.Categories;
using Exam.Common.SeedWork;
using MediatR;

namespace Exam.API.Application.Queries.Categories.GetCategoriesPaging
{
    public class GetCategoriesPagingQuery : IRequest<PagedList<CategoryDto>>
    {
        public string SearchKeyword { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
    }
}

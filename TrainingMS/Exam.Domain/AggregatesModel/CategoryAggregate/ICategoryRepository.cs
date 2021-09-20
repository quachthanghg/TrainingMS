using Exam.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Exam.Domain.AggregatesModel.CategoryAggregate
{
    public interface ICategoryRepository : IRepositoryBase<Category>
    {
        Task<Tuple<List<Category>, long>> GetCategoriesPagingAsync(string searchKeyword, int pageIndex, int pageSize);

        Task<Category> GetCategoriesByIdAsync(string id);

        Task<Category> GetCategoriesByNameAsync(string name);
    }
}

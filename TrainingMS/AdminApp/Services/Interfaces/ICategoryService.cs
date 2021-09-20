using Exam.Common.Dtos.Exam.Categories;
using Exam.Common.SeedWork;
using System.Threading.Tasks;

namespace AdminApp.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<PagedList<CategoryDto>> GetCategoriesPagingAsync(CategoryFilter categoryFilter);
        Task<CategoryDto> GetCategoryByIdAsync(string id);
        Task<bool> CreateAsync(CreateCategoryRequest request);
        Task<bool> UpdateAsync(UpdateCategoryRequest request);
        Task<bool> DeleteAsync(string id);
    }
}

using BlazorAdmin.ViewModels.ProductCategory;
using Exam.Common.Dtos.Report.API;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BlazorAdmin.Services.ProductCategory
{
    public interface IProductCategoryService
    {
        Task<List<ProductCategoryViewModel>> GetProductCategoires();
        Task<ProductCategoryViewModel> GetById(int id);

        Task<HttpResponseMessage> ExportExcel(ReportRequestDto reportRequestDto);
    }
}

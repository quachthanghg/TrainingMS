using BlazorAdmin.Services.ProductCategory;
using BlazorAdmin.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAdmin.Pages.ProductCategory
{
    public partial class ProductCategories
    {
        [Inject] private IProductCategoryService productCategoryService { get; set; }

        private List<ProductCategoryViewModel> productCategoryViewModels = new List<ProductCategoryViewModel>();

        protected override async Task OnInitializedAsync()
        {
            //productCategoryViewModels = await productCategoryService.GetProductCategoires();
        }

        async Task DeleteServer(ProductCategoryViewModel server)
        {
            var parameters = new DialogParameters { ["server"] = server };

            //var dialog = DialogService.Show<FormData>("Delete Server", parameters);
            //var result = await dialog.Result;

            //if (!result.Cancelled)
            //{
            //    productCategoryViewModels.RemoveAll(item => item.Id == server.Id);
            //}
        }
    }
}

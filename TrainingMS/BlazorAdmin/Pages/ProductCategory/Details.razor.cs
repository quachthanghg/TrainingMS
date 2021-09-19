using BlazorAdmin.Infrastructure;
using BlazorAdmin.Services.ProductCategory;
using BlazorAdmin.ViewModels.ProductCategory;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAdmin.Pages.ProductCategory
{
    public partial class Details
    {
        [Parameter]
        public int Id { get; set; }

        [Inject] private IProductCategoryService productCategoryService { get; set; }
        [Inject] private IJSRuntime JS { get; set; }

        private ProductCategoryViewModel productCategoryViewModel;

        protected override async Task OnInitializedAsync()
        {
            productCategoryViewModel = await productCategoryService.GetById(Id);
        }
    }
}

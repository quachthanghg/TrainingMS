using AdminApp.Services.Interfaces;
using Exam.Common.Dtos.Exam.Categories;
using Exam.Common.SeedWork;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace AdminApp.Services
{
    public class CategoryService : ICategoryService
    {
        public HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(CreateCategoryRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/category", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/category/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ApiResult<CategoryDto>> GetCategoryByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<CategoryDto>>($"/api/v1/category/{id}");
            return result;
        }

        public async Task<ApiResult<PagedList<CategoryDto>>> GetCategoriesPagingAsync(CategoryFilter categoryFilter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = categoryFilter.PageNumber.ToString(),
                ["pageSize"] = categoryFilter.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(categoryFilter.Name))
            {
                queryStringParam.Add("searchKeyword", categoryFilter.Name);
            }

            string url = QueryHelpers.AddQueryString("/api/v1/category/items", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<ApiResult<PagedList<CategoryDto>>>(url);
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateCategoryRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/category", request);
            return result.IsSuccessStatusCode;
        }
    }
}

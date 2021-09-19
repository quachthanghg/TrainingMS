using BlazorAdmin.Infrastructure;
using BlazorAdmin.ViewModels.ProductCategory;
using Exam.Common.Dtos.Report.API;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorAdmin.Services.ProductCategory
{
    public class ProductCategoryService : IProductCategoryService
    {
        private readonly HttpClient _httpClient;
        private readonly string _remoteCatalogServiceBaseUrl;
        private readonly string _remoteReportServiceBaseUrl;
        public ProductCategoryService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _remoteCatalogServiceBaseUrl = $"{configuration.GetSection("CatalogUrl").Value}/api/v1";
            _remoteReportServiceBaseUrl = $"{configuration.GetSection("ReportUrl").Value}/api​/v1​/Export​";
        }

        public async Task<ProductCategoryViewModel> GetById(int id)
        {
            var uri = API.ProductCategory.GetById(_remoteCatalogServiceBaseUrl, id);

            var responseString = await _httpClient.GetStringAsync(uri);

            var catalog = JsonSerializer.Deserialize<ProductCategoryViewModel>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return catalog;
        }

        public async Task<List<ProductCategoryViewModel>> GetProductCategoires()
        {
            var uri = API.ProductCategory.GetProductCategory(_remoteCatalogServiceBaseUrl);

            var responseString = await _httpClient.GetStringAsync(uri);

            var catalog = JsonSerializer.Deserialize<List<ProductCategoryViewModel>>(responseString, new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

            return catalog;
        }
        public async Task<HttpResponseMessage> ExportExcel(ReportRequestDto reportRequestDto)
        {
            var uri = API.ReportAPI.UrlBase(_remoteReportServiceBaseUrl);
            uri = "https://localhost:44313/api/v1/Export/export-excel";
            var basketContent = new StringContent(JsonSerializer.Serialize(reportRequestDto), System.Text.Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync(uri, basketContent);

            return response;
        }
    }
}

using AdminApp.Services.Interfaces;
using Exam.Common.Dtos.Exam.Questions;
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
    public class QuestionService : IQuestionService
    {
        public HttpClient _httpClient;

        public QuestionService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<bool> CreateAsync(CreateQuestionRequest request)
        {
            var result = await _httpClient.PostAsJsonAsync("/api/v1/question", request);
            return result.IsSuccessStatusCode;
        }

        public async Task<bool> DeleteAsync(string id)
        {
            var result = await _httpClient.DeleteAsync($"/api/v1/Question/{id}");
            return result.IsSuccessStatusCode;
        }

        public async Task<ApiResult<QuestionDto>> GetQuestionByIdAsync(string id)
        {
            var result = await _httpClient.GetFromJsonAsync<ApiResult<QuestionDto>>($"/api/v1/question/{id}");
            return result;
        }

        public async Task<ApiResult<PagedList<QuestionDto>>> GetCategoriesPagingAsync(QuestionFilter QuestionFilter)
        {
            var queryStringParam = new Dictionary<string, string>
            {
                ["pageIndex"] = QuestionFilter.PageNumber.ToString(),
                ["pageSize"] = QuestionFilter.PageSize.ToString()
            };

            if (!string.IsNullOrEmpty(QuestionFilter.Name))
            {
                queryStringParam.Add("searchKeyword", QuestionFilter.Name);
            }

            string url = QueryHelpers.AddQueryString("/api/v1/question/items", queryStringParam);

            var result = await _httpClient.GetFromJsonAsync<ApiResult<PagedList<QuestionDto>>>(url);
            return result;
        }

        public async Task<bool> UpdateAsync(UpdateQuestionRequest request)
        {
            var result = await _httpClient.PutAsJsonAsync($"/api/v1/question", request);
            return result.IsSuccessStatusCode;
        }
    }
}

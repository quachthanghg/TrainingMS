using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorAdmin.Infrastructure
{
    public static class API
    {
        public static class ProductCategory
        {
            public static string GetProductCategory(string baseUri) => $"{baseUri}/ProductCategory/items";
            public static string GetById(string baseUri, int id) => $"{baseUri}/ProductCategory/items/{id}";
            public static string AddItemToBasket(string baseUri) => $"{baseUri}/basket/items";
            public static string UpdateBasketItem(string baseUri) => $"{baseUri}/basket/items";

            public static string GetOrderDraft(string baseUri, string basketId) => $"{baseUri}/order/draft/{basketId}";
        }

        public static class ReportAPI
        {
            public static string UrlBase(string baseUri) => $"{baseUri}/export-excel";
        }
    }
}

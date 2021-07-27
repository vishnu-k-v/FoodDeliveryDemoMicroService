using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Infra
{
    public static class API
    {
        public static class Restaurant
        {
            public static string GetRestaurants(string baseUri) => $"{baseUri}/GetRestaurants";

            public static string AddItemToBasket(string baseUri) => $"{baseUri}/basket/items";
            public static string UpdateBasketItem(string baseUri) => $"{baseUri}/basket/items";

            public static string GetOrderDraft(string baseUri, string basketId) => $"{baseUri}/order/draft/{basketId}";
        }
    }
}

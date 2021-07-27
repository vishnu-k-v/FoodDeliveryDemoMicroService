using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WebApp.Infra;
using WebApp.Models;

namespace WebApp.Services
{
    public class RestaurantService : IRestaurantService
    {

        private readonly HttpClient _apiClient;
        private readonly ILogger<RestaurantService> _logger;
        private readonly string _restaurantUrl;
        private readonly IConfiguration _configuration;
        public RestaurantService(HttpClient httpClient,
                                ILogger<RestaurantService> logger,
                                IConfiguration configuration)
        {
            _restaurantUrl = configuration.GetValue<string>("restaurantUrl");
            _apiClient = httpClient;
        }

        public async Task<List<Restaurants>> GetItems(string id)
        {
            string uri = _restaurantUrl + "Restaurant/GetItems/" + id;
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(responseString) ?
                new List<Restaurants>() :
                JsonSerializer.Deserialize<List<Restaurants>>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }

        public async Task<List<Restaurants>> GetRestaurants()
        {
            //var uri = API.Restaurant.GetRestaurants(_restaurantUrl);
            string uri = _restaurantUrl + "Restaurant/GetRestaurants";
            var response = await _apiClient.GetAsync(uri);
            var responseString = await response.Content.ReadAsStringAsync();
            return string.IsNullOrEmpty(responseString) ?
                new List<Restaurants>() :
                JsonSerializer.Deserialize<List<Restaurants>>(responseString, new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                });
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;

namespace WebApp.Services
{
    public interface IRestaurantService
    {
        Task<List<Restaurants>> GetRestaurants();
        Task<List<Restaurants>> GetItems(string id);
    }
}

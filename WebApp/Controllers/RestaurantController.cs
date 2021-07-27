using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class RestaurantController : Controller
    {
        // GET: RestaurantController
        private readonly IRestaurantService _restaurantService;
        public RestaurantController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public async Task<ActionResult> Index()
        {
            List<Restaurants> rests = new List<Restaurants>();
            return View(await _restaurantService.GetRestaurants());
        }


    }
}

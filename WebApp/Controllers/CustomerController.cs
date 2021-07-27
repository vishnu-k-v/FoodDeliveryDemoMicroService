using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IRestaurantService _restaurantService;
        public CustomerController(IRestaurantService restaurantService)
        {
            _restaurantService = restaurantService;
        }
        public async Task<ActionResult> Index()
        {
            List<SelectListItem> retaurants = new List<SelectListItem>();
            var m = await _restaurantService.GetRestaurants();
            foreach (var item in m)
            {
                retaurants.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
            }

            ViewBag.retaurants = retaurants;

            List<SelectListItem> restItems = new List<SelectListItem>();
            var itemwithIds = await _restaurantService.GetItems(m.FirstOrDefault().id.ToString());
            foreach (var item in itemwithIds)
            {
                restItems.Add(new SelectListItem { Text = item.Name, Value = item.id.ToString() });
            }

            ViewBag.restItems = restItems;
            List<Restaurants> restaurants = new List<Restaurants>();
            return View(restaurants);
        }

        public async Task<ActionResult> Order()
        {
            return RedirectToAction("Index");
        }


    }
}

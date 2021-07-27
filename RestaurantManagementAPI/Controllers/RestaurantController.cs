using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantManagementAPI.DataAccess;
using RestaurantManagementAPI.Models;
using Messaging;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestaurantManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly RestaurantDbContext _context;
        private readonly IMessagePublisher _messagePublisher;
        public RestaurantController(RestaurantDbContext context,
            IMessagePublisher messagePublisher)
        {
            _context = context;
            _messagePublisher = messagePublisher;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        [Route("GetRestaurants")]
        public IEnumerable<Restaurant> Get()
        {
            return _context.Restaurant.AsEnumerable();
        }

        [HttpGet]
        [Route("GetItems/{id}")]
        public IEnumerable<Item> GetItems(Guid id)
        {
            return _context.Item.Where(a => a.RestaurantId == id).AsEnumerable();
        }

        [HttpPost]
        [Route("Order")]
        public ActionResult Order(Orders Ord)
        {
            _context.Orders.Add(Ord);
            _context.SaveChanges();
            OrderCreated orderCreated = new OrderCreated()
            {
                CustomerId = Ord.CustomerId,
                Id = Ord.Id,
                Items = _context.Item.Where(a => Ord.Itsmsid.Contains(a.Id))
                            .Select(h => new Item
                            {
                                Id = h.Id,
                                Name = h.Name
                            }).ToList()
            };
            _messagePublisher.PublishMessageAsync("OrderCreated", orderCreated, "");
            return Ok();
        }


    }
}

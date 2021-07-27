using CustomerManagementAPI.DataAccess;
using CustomerManagementAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {

        private readonly CustomerDbContext _context;
        public CustomerController(CustomerDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IEnumerable<Orders> GetMyOrders(Guid customerId)
        {
            return _context.Orders.Include("Items").AsEnumerable();
           
        }

    }
}

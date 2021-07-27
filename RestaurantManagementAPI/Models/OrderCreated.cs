using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementAPI.Models
{
    public class OrderCreated : Orders
    {
        public List<Item> Items { get; set; }
    }
}

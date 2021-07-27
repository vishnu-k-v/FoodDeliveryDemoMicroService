using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public int CustomerId { get; set; }
        public List<Items> Items { get; set; }
    }
    public class Items
    {
        public Guid Id { get; set; }
        public Guid ItemId { get; set; }
        public int ItemName { get; set; }
        public int Quantity { get; set; }
    }
}

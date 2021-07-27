using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantManagementAPI.Models
{
    public class Orders
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public List<Guid> Itsmsid { get; set; }
    }
   
}

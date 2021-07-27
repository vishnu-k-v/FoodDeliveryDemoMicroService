using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CustomerManagementAPI.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}

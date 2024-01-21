using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerService.Domain
{
    public class Order
    {
        public int OrderNumber { get;set; }

        public DateTime OrderDate { get;set; }

        public string DeliveryAddress { get;set; }

        public OrderItem OrderItem { get;set; }
        public DateTime DeliveryExpected { get; set; }
    }
}

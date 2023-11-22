using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_CRUD
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public DateTime OrderCreateDate { get; set; }
        public string ProviderName { get; set; }
        public string OrderItemName { get; set; }
        public decimal OrderItemQuantity { get; set; }

        public string OrderItemUnit { get; set; }
    }
}

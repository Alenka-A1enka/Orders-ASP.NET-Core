using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Orders_CRUD
{
    class OrderItem
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        public Order? Order { get; set; }

        public string Name { get; set; }

        [Precision(18, 3)]
        public decimal Quantity { get; set; }

        public string Unit { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreWarehouse.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public double Quantity { get; set; }
        public int StoreId { get; set; }
        public string Status { get; set; } = "";
        public DateTime Date { get; set; }
    }
}

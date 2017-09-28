using System;

namespace Repositories.Models
{
    public class OrderDetail
    {
        public int ProductId { get; set; }
        public Product Products { get; set; }

        public int OrderId { get; set; }
        public Order Orders { get; set; }
        public string Article { get; set; }

        public short Quantity { get; set; }

        public decimal Price { get; set; }
       
        public decimal Vat { get; set; }
        public string Notes { get; set; }
        
       
    }
}

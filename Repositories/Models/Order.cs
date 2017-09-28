using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Repositories.Models
{
    public class Order
    {
        public Order()
        {
            this.OrderODs = new HashSet<OrderDetail>();
        }

        public int OrderId { get; set; }
       
        public int OrderNumber { get; set; }
      
        public DateTime OrderDate { get; set; }
      
        public DateTime RequiredDate { get; set; }
        //public DateTime? ShippedDate { get; set; }
        //public string OrderName { get; set; }

        public bool IsOffer { get; set; }
        public string OfferlDetails { get; set; }
        public decimal AdvancePaymentTax { get; set; }

       

        public bool Paid { get; set; }


        public int CustomerId { get; set; }
        public Customer CustomerOrders { get; set; }

        public ICollection<OrderDetail> OrderODs { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Repositories.Models
{
    public class Product
    {
        public Product()
        {
            this.ProODs = new HashSet<OrderDetail>();
        }

        public int ProductId { get; set; }
        public string Article { get; set; }
        public string SupplierName { get; set; }
       
       
        public decimal Price { get; set; }
        public decimal Vat { get; set; }
        public decimal AdvancePaymentTax { get; set; }
        public string Notes { get; set; }

        public int? CategoryId { get; set; }
        public Category ProtuctCategorys { get; set; }
        
        public ICollection<OrderDetail> ProODs { get; set; }
     
    }
}

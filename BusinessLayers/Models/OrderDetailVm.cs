using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLayers.Models
{
    public class OrderDetailVm
    {
        public int OrderId { get; set; }
        public int ProductId { get; set; }

        public OrderVm OrdersVm { get; set; }
        public ProductVm ProductsVm { get; set; }

        //[Required]
        //public string Article { get; set; }

        [DisplayName("Qty")]
        [Range(-100000, 100000, ErrorMessage = "Mängden måste vara mellan 1 och 100000")]
        public int Quantity { get; set; }

        [Range(0.01, 999999999, ErrorMessage = "Priset måste vara mellan 0,01 och 999999999")]
        public decimal Price { get; set; }
        [DisplayName("Moms")]
        [Range(0.00, 100, ErrorMessage = "Moms måste vara ett% mellan 0 och 100")]
        public decimal Vat { get; set; }

        
        public string Notes { get; set; }

        #region Calculated fields
        public decimal Total
        {
            get
            {
                return Quantity * Price;
            }
        }
        
        public decimal VATAmount
        {
            get
            {
                return TotalPlusVAT - Total;
            }
        }

        public decimal TotalPlusVAT
        {
            get
            {
                return Total * (1 + Vat / 100);
            }
        }
        #endregion
    }
}

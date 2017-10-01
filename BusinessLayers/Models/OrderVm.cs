using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace BusinessLayers.Models
{
    public class OrderVm
    {
        public OrderVm()
        {
            this.OrderDetailsVm = new HashSet<OrderDetailVm>();
        }

        public int OrderId { get; set; }
        [DisplayName("Order NO")]
        public int OrderNumber { get; set; }
        [DisplayName("Skapad Datum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        [DisplayName("Förfallodatum")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime RequiredDate { get; set; }

        public bool IsOffer { get; set; }
        [DisplayName("erbjuda detaljer")]
        public string OfferlDetails { get; set; }
        [DisplayName("Förskottsbetalningsskatt")]
        [Range(0.00, 100.0, ErrorMessage = "Värdet måste vara en% mellan 0 och 100")]
        public decimal AdvancePaymentTax { get; set; }

        [DisplayName("Betald")]
        public bool Paid { get; set; }

        public int CustomerId { get; set; }
        public CustomerVm CustomerOrdersVm { get; set; }
        public ICollection<OrderDetailVm> OrderDetailsVm { get; set; }


        #region Calculated fields
        public decimal VATAmount
        {
            get
            {
                return this.TotalWithVat - this.NetTotal;
            }
        }

        /// <summary>
        /// Total before TAX
        /// Totalt före skatt
        /// </summary>
        public decimal NetTotal
        {
            get
            {
                if (OrderDetailsVm == null)
                    return 0;
                return OrderDetailsVm.Sum(i => i.Total);
                //return OrderDetailsVm.Sum(i => i.Total);
            }
        }

        public decimal AdvancePaymentTaxAmount
        {
            get
            {
                if (OrderDetailsVm == null)
                    return 0;

                return NetTotal * (AdvancePaymentTax / 100);
            }
        }

        /// <summary>
        /// Total with tax
        /// Totalt med skatt
        /// </summary>
        public decimal TotalWithVat
        {
            get
            {
                if (OrderDetailsVm == null)
                    return 0;

                return OrderDetailsVm.Sum(i => i.TotalPlusVAT);
            }
        }

        /// <summary>
        /// Total with VAT minus advanced tax payment 
        /// Totalt med moms minus förskottsskatt
        /// </summary>
        public decimal TotalToPay
        {
            get
            {
                return TotalWithVat - AdvancePaymentTaxAmount;
            }
        }
        #endregion

    }
}

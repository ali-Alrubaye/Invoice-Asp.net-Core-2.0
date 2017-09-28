using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayers.Models
{
    public class ProductVm
    {
        public ProductVm()
        {
            this.OrderDetailsVm = new HashSet<OrderDetailVm>();
        }

        public int ProductId { get; set; }
        [DisplayName("Article")]
        [Required]
        public string Article { get; set; }
        [DisplayName("Leverantörsnamn")]
        public string SupplierName { get; set; }
        [Range(0.1, 999999999, ErrorMessage = "Priset måste vara mellan 1 och 999999999")]
        public decimal Price { get; set; }
        /// <summary>
        /// الضريبة أو الجباية هي مبلغ نقدي تتقاضاه الدولة من الأشخاص والمؤسسات بهدف تمويل نفقات الدولة.
        /// </summary>
        [DisplayName("Moms")]
        [Range(0.00, 100.0, ErrorMessage = "Moms måste vara ett% mellan 0 och 100")]
        public decimal VatProduct { get; set; }

        /// <summary>
        /// دفع مسبق (بالإنجليزية الأمريكية: advance payment) هو دفع جزء من مبلغ متعاقد عليه مسبقا عن توريد بضاعة أو خدمات، بينما الفاتورة ترسل إلى المشتري بعد توريد البضاعة أو الخدمات.
        /// </summary>
        [DisplayName("Förskottsbetalningsskatt")]
        [Range(0.00, 100.0, ErrorMessage = "Värdet måste vara en% mellan 0 och 100")]
        public decimal AdvancePaymentTax { get; set; }
        public string Notes { get; set; }

        public int CategoryId { get; set; }
        [DisplayName("Category")]
        public  CategoryVm CategorysVm { get; set; }

        public ICollection<OrderDetailVm> OrderDetailsVm { get; set; }

        #region Calculated fields
        public decimal SubTotal => Price;

        public decimal TotalWithVat => Price + (Price * VatProduct / 100);

        public decimal VatAmount => TotalWithVat - SubTotal;
        #endregion

    }
}

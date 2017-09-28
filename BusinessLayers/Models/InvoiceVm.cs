using System.Collections.Generic;

namespace BusinessLayers.Models
{
    public class InvoiceVm 
    {
        
        public IEnumerable<OrderDetailVm> OrdDetInstVMs { get; set; }
        public IEnumerable<CustomerVm> CustomerInstVMs { get; set; }

        public IEnumerable<OrderVm> OrderInstVMs { get; set; }

        public IEnumerable<ProductVm> ProdInstVMs { get; set; }
        public IEnumerable<CategoryVm> CatInstVMs { get; set; }
        public IEnumerable<CompanyVm> CompInstVMs { get; set; }


    }
}

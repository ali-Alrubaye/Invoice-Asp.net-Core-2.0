using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BusinessLayers.Models
{
    public class CategoryVm
    {
        public CategoryVm()
        {
            this.ProductsVm = new HashSet<ProductVm>();
        }

      
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public ICollection<ProductVm> ProductsVm { get; set; }
    }
}

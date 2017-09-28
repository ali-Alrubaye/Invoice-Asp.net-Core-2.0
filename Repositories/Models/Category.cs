using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Models
{
    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}

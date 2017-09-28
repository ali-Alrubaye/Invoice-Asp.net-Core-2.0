using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Models
{
    public class Invoice
    {
        public IEnumerable<OrderDetail> OrdDetInsts { get; set; }
        public IEnumerable<Order> OrdInsts { get; set; }
        public IEnumerable<Product> ProInsts { get; set; }
        public IEnumerable<Category> CatInsts { get; set; }
        public IEnumerable<Company> CompInsts { get; set; }
        public IEnumerable<Customer> CustomerInsts { get; set; }
    }
}

using System.Collections.Generic;

namespace Repositories.Models
{
    public class Customer
    {
        public Customer()
        {
            this.Orders = new HashSet<Order>();
        }

     
        public int CustomerId { get; set; }
        public string FirstMidName { get; set; }
        public string LastName { get; set; }
        public string ContactPerson { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Fax { get; set; }
        
        public string Email { get; set; }
        public string Notes { get; set; }
        
        public int CompanyId { get; set; }

        public Company Companys { get; set; }

        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<Order> Orders { get; set; }

    }
}

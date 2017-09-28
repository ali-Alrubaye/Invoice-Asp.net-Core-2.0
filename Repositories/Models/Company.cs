using System.Collections.Generic;

namespace Repositories.Models
{
    public class Company
    {
        public Company()
        {
            Customers = new HashSet<Customer>();
        }
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public string OrgNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string PostCode { get; set; }
        public string Region { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Phone2 { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Picture { get; set; }

        public ICollection<Customer> Customers { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayers.Models
{
    public class CompanyVm
    {
        public CompanyVm()
        {
            CustomersVm = new HashSet<CustomerVm>();
        }
        public int CompanyId { get; set; }
        [Display(Name = "CustomerInsts")]
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string OrgNumber { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required(ErrorMessage = "Postnummer krävs")]
        [DisplayName("Postnummer")]
        public string PostCode { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Country { get; set; }
        [Required(ErrorMessage = "Telephone required")]
        [DisplayName("Telephone")]
        public string Phone { get; set; }
        [DisplayName("Mobile")]
        public string Phone2 { get; set; }
        [Required]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Wrong email format")]
        public string Email { get; set; }
        public string Website { get; set; }
        public string Picture { get; set; }

        public ICollection<CustomerVm> CustomersVm { get; set; }
    }
}

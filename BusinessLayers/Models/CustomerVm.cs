using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BusinessLayers.Models
{
    public class CustomerVm
    {
        public CustomerVm()
        {
            this.OrdersVm = new HashSet<OrderVm>();
        }
        [Display(Name = "Number")]
        public int CustomerId { get; set; }
        [StringLength(50, ErrorMessage = "Förnamn kan inte vara längre än 50 tecken.")]
        [DisplayName("Förnamn Name")]
        [Required]
        public string FirstMidName { get; set; }
        [StringLength(50, ErrorMessage = "Efternamn får inte vara längre än 50 tecken.")]
        [DisplayName("Efternamn Name")]
        [Required]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Contact person required")]
        [DisplayName("Kontaktperson")]
        public string ContactPerson { get; set; }
        [Display(Name = "Kontakt Titel")]
        public string ContactTitle { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string City { get; set; }
        [Required(ErrorMessage = "Postnummer krävs")]
        [DisplayName("Postnummer")]
        public string PostCode { get; set; }
        [Required]
        public string Region { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Telefon krävs")]
        [DisplayName("Telefon")]
        public string Phone { get; set; }
        [DisplayName("Mobil")]
        public string Phone2 { get; set; }
        public string Fax { get; set; }
       
        [Required(ErrorMessage = "E-post krävs")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Fel email-format")]
        public string Email { get; set; }
        public string Notes { get; set; }

       
        public int CompanyId { get; set; }
        public CompanyVm CompanysVm { get; set; }

        [Display(Name = "Full Name")]
        public string FullName => LastName + ", " + FirstMidName;

        public ICollection<OrderVm> OrdersVm { get; set; }
        
    }
}

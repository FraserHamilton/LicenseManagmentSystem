using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class Customer
    {
        public int ID { get; set; }
        [Display(Name = "Company name")]
        public string CompanyName { get; set; }
        public string Address { get; set; }
        [Display(Name = "Contact Number")]
        public string ContactNumber { get; set; }

        public ICollection<LicenseKey> LicenseKeys { get; set; }
    }
}

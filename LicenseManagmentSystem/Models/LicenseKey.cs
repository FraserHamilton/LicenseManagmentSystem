using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class LicenseKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "License Key")]
        public int LicenseKeyID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        [Display(Name = "Expiry Date")]
        [DataType(DataType.Date)]
        public DateTime ExpiryDate { get; set; }
        public bool Active { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }

        public LicenseKey()
        {
            Active = true;
        }
    }
}

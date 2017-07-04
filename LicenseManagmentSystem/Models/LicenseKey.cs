using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class LicenseKey
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int LicenseKeyID { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        public DateTime ExpiryDate { get; set; }

        public Product Product { get; set; }
        public Customer Customer { get; set; }
    }
}

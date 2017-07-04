using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ProductID { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }

        public ICollection<LicenseKey> LicenseKeys { get; set; }
    }
}

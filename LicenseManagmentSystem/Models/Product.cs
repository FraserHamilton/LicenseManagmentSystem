using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class Product
    {
        public int ProductID { get; set; }
        public string Title { get; set; }
        public int Cost { get; set; }

        public ICollection<LicenseKey> LicenseKeys { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public long ContactNumber { get; set; }

        public ICollection<LicenseKey> LicenseKeys { get; set; }
    }
}

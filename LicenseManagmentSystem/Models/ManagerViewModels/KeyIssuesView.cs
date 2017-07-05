using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LicenseManagmentSystem.Models.ManagerViewModels
{
    public class KeyIssuesView
    {
        public IEnumerable<LicenseKey> LicenseKeysExpiring { get; set; }

        public IEnumerable<LicenseKey> LicenseKeys { get; set; }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LicenseManagmentSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace LicenseManagmentSystem.Data
{
    public class ManagerContext : DbContext
    {
        public ManagerContext(DbContextOptions<ManagerContext> options) : base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
    }
}

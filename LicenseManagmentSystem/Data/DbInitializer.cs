
using LicenseManagmentSystem.Models;
using System;
using System.Linq;

namespace LicenseManagmentSystem.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ManagerContext context)
        {
            context.Database.EnsureCreated();

            // Look for any Customers.
            if (context.Customers.Any())
            {
                return;   // DB has been seeded
            }

            var Customers = new Customer[]
            {
            new Customer{CompanyName="Carson Tech",Address="Alexander Ave",ContactNumber="07700900058"},
            new Customer{CompanyName="Meredith Solutions",Address="Alonso Pl",ContactNumber="07723900231"},
            new Customer{CompanyName="Arturo Global Solutions",Address="Anand St",ContactNumber="07755440058"},
            new Customer{CompanyName="Gytis",Address="Barzdukas Ave",ContactNumber="07700343458"},
            new Customer{CompanyName="Yan Tech",Address="Li St",ContactNumber="07700959678"},
            new Customer{CompanyName="Peggy Cloud Systems",Address="Justice Ln",ContactNumber="07700903532"},
            new Customer{CompanyName="Laura Systems",Address="Norman Pl",ContactNumber="07700901111"},
            new Customer{CompanyName="Nino IT",Address="Olivetto Ave",ContactNumber="07700939678"}
            };
            foreach (Customer s in Customers)
            {
                context.Customers.Add(s);
            }
            context.SaveChanges();

            var Products = new Product[]
            {
            new Product{ProductID=1050,Title="SickRar",Cost=3},
            new Product{ProductID=4022,Title="VOIPer",Cost=5},
            new Product{ProductID=4041,Title="SalesMan Man Manager",Cost=11},
            };
            foreach (Product c in Products)
            {
                context.Products.Add(c);
            }
            context.SaveChanges();

            var LicenseKeys = new LicenseKey[]
            {
            new LicenseKey{LicenseKeyID=15512,CustomerID=1,ProductID=1050,ExpiryDate=DateTime.Parse("2005-05-03")},
            new LicenseKey{LicenseKeyID=37893,CustomerID=1,ProductID=4022,ExpiryDate=DateTime.Parse("2007-09-01")},
            new LicenseKey{LicenseKeyID=22222,CustomerID=1,ProductID=4041,ExpiryDate=DateTime.Parse("2005-06-17")},
            new LicenseKey{LicenseKeyID=34532,CustomerID=2,ProductID=4041,ExpiryDate=DateTime.Parse("2005-09-22")},
            new LicenseKey{LicenseKeyID=15642,CustomerID=2,ProductID=4022,ExpiryDate=DateTime.Parse("2005-05-13")},
            new LicenseKey{LicenseKeyID=77865,CustomerID=2,ProductID=1050,ExpiryDate=DateTime.Parse("2005-08-20")},
            new LicenseKey{LicenseKeyID=12453,CustomerID=3,ProductID=1050,ExpiryDate=DateTime.Parse("2006-04-21")},
            new LicenseKey{LicenseKeyID=64332,CustomerID=4,ProductID=1050,ExpiryDate=DateTime.Parse("2005-07-05")},
            new LicenseKey{LicenseKeyID=54682,CustomerID=4,ProductID=4022,ExpiryDate=DateTime.Parse("2005-06-06")},
            new LicenseKey{LicenseKeyID=79854,CustomerID=5,ProductID=4041,ExpiryDate=DateTime.Parse("2007-09-01")},
            new LicenseKey{LicenseKeyID=21035,CustomerID=6,ProductID=1050,ExpiryDate=DateTime.Parse("2005-08-01")},
            new LicenseKey{LicenseKeyID=78451,CustomerID=7,ProductID=4022,ExpiryDate=DateTime.Parse("2006-09-03")},
            };
            foreach (LicenseKey e in LicenseKeys)
            {
                context.LicenseKeys.Add(e);
            }
            context.SaveChanges();
        }
    }
}
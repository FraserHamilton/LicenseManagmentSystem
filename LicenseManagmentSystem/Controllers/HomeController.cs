using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LicenseManagmentSystem.Data;
using LicenseManagmentSystem.Models.ManagerViewModels;

namespace LicenseManagmentSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ManagerContext _context;

        public HomeController(ManagerContext context)
        {
            _context = context;
        }
            public IActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Reports()
        {
            IQueryable<NumberOfLicenses> data =
                from LicenseKey in _context.LicenseKeys
                group LicenseKey by LicenseKey.Product.Title into ProductGroup
                select new NumberOfLicenses()
                {
                    ProductName = ProductGroup.Key,
                    LicenseCount = ProductGroup.Count()
                };
            return View(await data.AsNoTracking().ToListAsync());
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}

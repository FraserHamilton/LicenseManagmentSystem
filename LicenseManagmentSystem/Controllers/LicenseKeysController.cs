using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LicenseManagmentSystem.Data;
using LicenseManagmentSystem.Models;
using LicenseManagmentSystem.Models.ManagerViewModels;

namespace LicenseManagmentSystem.Controllers
{
    public class LicenseKeysController : Controller
    {
        private readonly ManagerContext _context;

        public LicenseKeysController(ManagerContext context)
        {
            _context = context;
        }

        // GET: LicenseKeys
        public async Task<IActionResult> Index(String searchString, String searchOption)
        {
            IQueryable<LicenseKey> licenseKeys = _context.LicenseKeys.Include(l => l.Customer).Include(l => l.Product);
            IQueryable<LicenseKey> licenseissueKeys = _context.LicenseKeys.Include(l => l.Customer).Include(l => l.Product).Where(s => s.ExpiryDate >= DateTime.Today && s.ExpiryDate <= DateTime.Today.Date.AddDays(14));

            ViewData["CurrentFilter"] = searchString;
            ViewData["CurrentFilterSelection"] = searchOption;

            if (!String.IsNullOrEmpty(searchString))
            {
                if (String.Equals(searchOption, "KeySearch"))

                {
                    licenseKeys = licenseKeys.Where(s => s.LicenseKeyID.ToString().Contains(searchString));
                }
                else
                {
                    licenseKeys = licenseKeys.Where(s => s.Customer.CompanyName.Contains(searchString));
                }
            }

            

            var model = new KeyIssuesView
            {
                LicenseKeys = licenseKeys,
                LicenseKeysExpiring = licenseissueKeys
            };

            return View(model);
        }

        // GET: LicenseKeys/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseKey = await _context.LicenseKeys
                .Include(l => l.Customer)
                .Include(l => l.Product)
                .SingleOrDefaultAsync(m => m.LicenseKeyID == id);
            if (licenseKey == null)
            {
                return NotFound();
            }

            return View(licenseKey);
        }

        // GET: LicenseKeys/Create
        public IActionResult Create()
        {
            ViewData["CurrentFilter"] = GenKey();
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CompanyName");
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Title");
            return View();
        }

        // POST: LicenseKeys/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LicenseKeyID,CustomerID,ProductID,ExpiryDate")] LicenseKey licenseKey)
        {

            if (ModelState.IsValid)
            {
                _context.Add(licenseKey);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "CompanyName", licenseKey.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "Title", licenseKey.ProductID);
            return View(licenseKey);
        }

        private int GenKey()
        {
            Random generator = new Random();
            return generator.Next(10000, 99999);
        }

        // GET: LicenseKeys/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseKey = await _context.LicenseKeys.SingleOrDefaultAsync(m => m.LicenseKeyID == id);
            if (licenseKey == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID", licenseKey.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", licenseKey.ProductID);
            return View(licenseKey);
        }

        // POST: LicenseKeys/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LicenseKeyID,CustomerID,ProductID,ExpiryDate,Active")] LicenseKey licenseKey)
        {
            if (id != licenseKey.LicenseKeyID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(licenseKey);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LicenseKeyExists(licenseKey.LicenseKeyID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID", licenseKey.CustomerID);
            ViewData["ProductID"] = new SelectList(_context.Products, "ProductID", "ProductID", licenseKey.ProductID);
            return View(licenseKey);
        }

        // GET: LicenseKeys/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var licenseKey = await _context.LicenseKeys
                .Include(l => l.Customer)
                .Include(l => l.Product)
                .SingleOrDefaultAsync(m => m.LicenseKeyID == id);
            if (licenseKey == null)
            {
                return NotFound();
            }

            return View(licenseKey);
        }

        // POST: LicenseKeys/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var licenseKey = await _context.LicenseKeys.SingleOrDefaultAsync(m => m.LicenseKeyID == id);
            _context.LicenseKeys.Remove(licenseKey);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool LicenseKeyExists(int id)
        {
            return _context.LicenseKeys.Any(e => e.LicenseKeyID == id);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using garbage_collection.Data;
using garbage_collection.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace garbage_collection.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _context;

        public AdminController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Admin
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CitizenModel citizen)
        {
            if (ModelState.IsValid)
            {
                _context.Citizens.Add(citizen);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(citizen);
        }

        public IActionResult Citizens()
        {
            var list = _context.Citizens
                               .OrderBy(c => c.Id)
                               .ToList();
            return View(list);
        }

        // GET: Admin/AddBin
        [HttpGet]
        public IActionResult AddBin()
        {
            return View();
        }

        // POST: Admin/AddBin
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBin(BinModel bin)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Bins.Add(bin);
                    _context.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {
                    ModelState.AddModelError(string.Empty, "Error saving bin: " + ex.Message);
                }
            }
            return View(bin);
        }

        // GET: Admin/CitizenCollections - Form to enter citizen ID
        [HttpGet]
        public IActionResult CitizenCollections()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CitizenCollections(int citizenId)
        {
            var citizen = await _context.Citizens.FindAsync(citizenId);
            if (citizen == null)
            {
                ModelState.AddModelError("citizenId", "Citizen not found");
                return View("Index");
            }

            var citizenBins = await _context.Bins
                .Where(b => b.CitizenId == citizenId)
                .ToListAsync();

            var binIds = citizenBins.Select(b => b.Id).ToList();
            var collections = await _context.Collections
                .Where(c => binIds.Contains(c.Bin_id))
                .OrderByDescending(c => c.Collection_time)
                .ToListAsync();

            ViewBag.Citizen = citizen;
            ViewBag.Bins = citizenBins;
            ViewBag.Collections = collections;

            return View("CitizenCollectionsResult");
        }
    }
}
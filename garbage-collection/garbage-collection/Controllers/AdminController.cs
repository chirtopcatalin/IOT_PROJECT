using Microsoft.AspNetCore.Mvc;
using garbage_collection.Data;      // adjust to your actual Data namespace
using garbage_collection.Models;

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



    }
}

using garbage_collection.Data;
using garbage_collection.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace garbage_collection.Controllers
{
    public class CollectionController : Controller
    {
        private readonly AppDbContext _context;

        public CollectionController(AppDbContext context)
        {
            _context = context;
        }

        // GET: /Collection/
        public IActionResult Index()
        {
            var collections = _context.CollectionModels.ToList();
            return View(collections);
        }
    }
}

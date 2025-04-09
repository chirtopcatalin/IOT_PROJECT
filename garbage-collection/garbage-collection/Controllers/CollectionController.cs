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
            return View(); //return la file-UL cu numele metodei (ex: "Index.cshtml") din folderul Collections
        }

        public IActionResult TabelColectari()
        {
            var data = _context.collections.ToList();
            return View(data);
        }

        [HttpPost("api/collection/add")]
        public IActionResult Add([FromBody] CollectionModel collection)
        {
            if (collection == null)
                return BadRequest("Invalid data.");

            _context.collections.Add(collection);
            _context.SaveChanges();

            return Ok(new { message = "Collection added successfully", collection });
        }

    }
}

using garbage_collection.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace garbage_collection.Controllers
{
    public class CollectionController : Controller
    {
        // GET: /Collection/
        public IActionResult Index()
        {
            // Example data - in a real app, this data would come from a database
            var collections = new List<CollectionModel>
            {
                new CollectionModel { Id = 1, Bin_id = 101, Collection_time = DateTime.Now },
                new CollectionModel { Id = 2, Bin_id = 102, Collection_time = DateTime.Now.AddHours(1) },
                new CollectionModel { Id = 3, Bin_id = 103, Collection_time = DateTime.Now.AddHours(2) }
            };

            return View(collections);  // Passing the list of collections to the view
        }
    }
}

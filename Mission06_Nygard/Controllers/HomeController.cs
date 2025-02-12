using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Mission06_Nygard.Models;

namespace Mission06_Nygard.Controllers
{
    public class HomeController : Controller
    {

        private EnterMoviesContext _context;
        public HomeController(EnterMoviesContext temp) 
        { 
            _context= temp;
        }


        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            if (string.IsNullOrEmpty(response.LentTo))
            {
                response.LentTo = null;
            }

            if (string.IsNullOrEmpty(response.Notes))
            {
                response.Notes = null;
            }
            else if (response.Notes.Length > 25)
            {
                ModelState.AddModelError("Notes", "Notes must be 25 characters or less.");
            }

            if (!ModelState.IsValid)
            {
                return View(response); // Return the view with validation errors
            }

            _context.Movies.Add(response); // adds record to the database
            _context.SaveChanges(); // saves changes
            return View("Confirmation", response);
        }



    }
}

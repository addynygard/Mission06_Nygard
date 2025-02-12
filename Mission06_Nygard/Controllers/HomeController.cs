using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Mission06_Nygard.Models;

// Creates controllers
namespace Mission06_Nygard.Controllers
{
    public class HomeController : Controller
    {
        // Makes a private instance of the EnterMoviesContext class that everything can see
        private EnterMoviesContext _context;
        // Constructor that takes in a EnterMoviesContext object and assigns it to the private instance
        public HomeController(EnterMoviesContext temp) 
        { 
            _context= temp;
        }

        // Returns the Index view
        public IActionResult Index()
        {
            return View();
        }
        // Returns the About view
        public IActionResult About()
        {
            return View();
        }

        // Returns the EnterMovies view
        [HttpGet]
        public IActionResult EnterMovies()
        {
            return View();
        }

        // Posts the EnterMovies view so data will go into the database

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            // If the response.LentTo is empty, set it to null
            if (string.IsNullOrEmpty(response.LentTo))
            {
                response.LentTo = null;
            }
            // If the response.Notes is empty, set it to null
            if (string.IsNullOrEmpty(response.Notes))
            {
                response.Notes = null;
            }
            // If the response.Notes is greater than 25 characters, add a model error
            else if (response.Notes.Length > 25)
            {
                ModelState.AddModelError("Notes", "Notes must be 25 characters or less.");
            }
            // If the model state is not valid, return the view with the response
            if (!ModelState.IsValid)
            {
                return View(response); // Return the view with validation errors
            }

            _context.Movies.Add(response); // adds record to the database
            _context.SaveChanges(); // saves changes
            return View("Confirmation", response); // Return the confirmation view with the response
        }



    }
}

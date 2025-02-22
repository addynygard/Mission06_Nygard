using System.Diagnostics;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            // puts all the categories into a list, gets the values from Categories table
            

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();

            return View(new Movie());
            // put "EnterMovies" in the view
        }



        // Posts the EnterMovies view so data will go into the database

        //[HttpPost]

        //public IActionResult EnterMovies(Movie response)
        //{
        //    if (string.IsNullOrEmpty(response.LentTo))
        //        {
        //            response.LentTo = null;
        //        }
        //    if (string.IsNullOrEmpty(response.Notes))
        //        {
        //            response.Notes = null;
        //        }
        //    else if (response.Notes.Length > 25)
        //        {
        //            ModelState.AddModelError("Notes", "Notes must be 25 characters or less.");
        //        }
        //    if (!ModelState.IsValid)
        //        {
        //            return View(response);
        //        }

        //    if (_context.Movies.Any(m => m.MovieID == response.MovieID))
        //        {
        //            _context.Movies.Update(response); // 
        //        }
        //    else
        //        {
        //            _context.Movies.Add(response);
        //        }

        //    _context.SaveChanges();
        //    return View("Confirmation", response);
        //}

        //[HttpPost]
        //public IActionResult EnterMovies(Movie response)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Movies.Add(response);
        //        _context.SaveChanges();
        //        return View("Confirmation", response);
        //    }
        //    else
        //    {
        //        //ViewBag.Categories = _context.Categories
        //        //       .ToList();
        //        ViewBag.Categories = _context.Categories
        //        .OrderBy(x => x.CategoryName).ToList();

        //        return View(response);
        //    }
        //}

        [HttpPost]
        public IActionResult EnterMovies(Movie response)
        {
            if (ModelState.IsValid)
            {
                if (response.MovieId == 0)
                {
                    // Add new movie
                    _context.Movies.Add(response);
                }
                else
                {
                    // Update existing movie
                    _context.Movies.Update(response);
                }

                _context.SaveChanges();
                return View("Confirmation", response);
            }
            else
            {
                ViewBag.Categories = _context.Categories
                    .OrderBy(x => x.CategoryName).ToList();

                return View(response);
            }
        }



        public IActionResult ViewMovies()
        {
            // using Linq to pull the data from the database and put it in a list
           var movies = _context.Movies // this is the table name, and then the modifiers below
                .OrderBy(x => x.Year).ToList(); 

            return View(movies);
        }

        [HttpGet]
        public IActionResult Edit(int id)
            // int represents the record id; that is just a name (see entermovies.cshtml
        {

            var recordToEdit = _context.Movies
                .Single(x => x.MovieId == id);  // to find which record to edit; uniquly identify Movie with MovieID

            ViewBag.Categories = _context.Categories
                .OrderBy(x => x.CategoryName).ToList();


            // with just a return pointed to EnterMovies, there are no Categories loaded up; those are in the class a few lines up called EnterMovies
            // so instead of return, do "RedirectToAction" and then the name of the method
            return View("EnterMovies", recordToEdit);
        }
        [HttpPost]

        public IActionResult Edit(Movie app)
        {
            _context.Update(app);
            _context.SaveChanges();

            return RedirectToAction("ViewMovies"); // ? Redirects to ViewMovies after editing
        }

    }
}

using Microsoft.AspNetCore.Mvc;
using Mission06_Kennedy.Models;
using Microsoft.EntityFrameworkCore;

namespace Mission06_Kennedy.Controllers
{
    public class HomeController : Controller
    {
        // 1. Create a private variable for the database context
        private MovieContext _context;

        // 2. The constructor "injects" the database context so we can use it
        public HomeController(MovieContext temp)
        {
            _context = temp;
        }


        [HttpGet]
        public IActionResult MovieList()
        {
            // We add .Include() to pull in the related Category data
            var movies = _context.Movies.Include(x => x.Category).ToList();

            return View(movies);
        }
        public IActionResult Index() => View();
        public IActionResult AboutJoel() => View();

        [HttpGet]
        public IActionResult MovieForm()
        {
            ViewBag.Categories = _context.Categories.ToList();
            return View(new Movie()); // We pass a blank movie object so the hidden MovieId isn't null
        }


        [HttpPost]
        public IActionResult Edit(Movie updatedInfo)
        {
            // Tell the database context to update this specific record
            _context.Update(updatedInfo);

            // Save the changes
            _context.SaveChanges();

            // Send them back to the list of movies to see their changes
            return RedirectToAction("MovieList");
        }
        //add the edit funciton
        [HttpGet]
        public IActionResult Edit(int id)
        {
            // Find the specific movie by its ID
            var recordToEdit = _context.Movies.Single(x => x.MovieId == id);

            // We also need to send the list of Categories to the view so your dropdown menu works
            ViewBag.Categories = _context.Categories.ToList();

            // Send the specific movie record to the MovieForm view so the fields pre-fill
            return View("MovieForm", recordToEdit);
        }
        // 3. The POST method: This runs when the user clicks the "Add Movie" button
        [HttpPost]
        public IActionResult MovieForm(Movie response)
        {
            if (ModelState.IsValid) // Optional: Checks if data matches model rules
            {
                _context.Movies.Add(response); // Adds record to the SQLite database
                _context.SaveChanges();        // Saves changes permanently
                return View("Confirmation");  // Redirects to a success page
            }

            return View(response); // If something is wrong, stay on the form
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            // Find the specific movie they clicked on
            var recordToDelete = _context.Movies.Single(x => x.MovieId == id);

            // Pass that specific movie to the Delete confirmation view
            return View(recordToDelete);
        }
        [HttpPost]
        public IActionResult Delete(Movie movieToDelete)
        {
            // Tell the database context to remove this specific record
            _context.Movies.Remove(movieToDelete);

            // Save the changes permanently
            _context.SaveChanges();

            // Send them back to the list of movies to see it's gone
            return RedirectToAction("MovieList");
        }
    }
}

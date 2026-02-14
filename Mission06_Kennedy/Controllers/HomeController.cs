using Microsoft.AspNetCore.Mvc;
using Mission06_Kennedy.Models;

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

        public IActionResult Index() => View();
        public IActionResult AboutJoel() => View();

        [HttpGet]
        public IActionResult MovieForm() => View();

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
    }
}

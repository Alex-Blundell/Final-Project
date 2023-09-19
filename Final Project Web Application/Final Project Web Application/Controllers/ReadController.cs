using Final_Project_Web_Application.Data;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ReadController : Controller
    {
        private readonly ApplicationDBContext Context;

        public ReadController(ApplicationDBContext DBContext)
        {
            Context = DBContext;
        }

        public IActionResult Index(string Genre)
        {
            // Show Basic List of Book Objects.
            IEnumerable<Models.Book> RAWBookList = null; // Get Book Data from the DB Context.
            IEnumerable<Models.Book> BookList = null; // Edited Book List.

            if(Genre != null)
            {
                foreach(Models.Book ThisBook in RAWBookList)
                {
                    // Check Selected Genre against the Genre for the Book.
                    // Add to the BookList.
                }
            }

            // Send BookList to the View.
            return View(BookList);
        }
    }
}

using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
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
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            string TempLoginCheck = (string)TempData["TempLogin"];

            if (TempLoginCheck == "Yes")
            {
                TempData["HasLoggedIn"] = TempData["TempLogin"];
                TempData["UserID"] = TempData["TempUserID"];
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            // Show Basic List of Book Objects.
            IEnumerable<Models.Book> RAWBookList = null; // Get Book Data from the DB Context.
            IEnumerable<Models.Book> BookList = null; // Edited Book List.

            if(Genre != null)
            {
                /*foreach(Models.Book ThisBook in RAWBookList)
                {
                    // Check Selected Genre against the Genre for the Book.
                    // Add to the BookList.
                }*/
            }

            // Send BookList to the View.
            //return View(BookList);
            return View(new List<Book>());
        }
    }
}

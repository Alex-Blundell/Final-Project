using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Diagnostics;

namespace Final_Project_Web_Application.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDBContext Context;

        public HomeController(ILogger<HomeController> logger, ApplicationDBContext DBContext)
        {
            _logger = logger;
            Context = DBContext;
        }

        [HttpPost]
        public IActionResult WriteCookie(string Value)
        {
            HttpContext.Session.SetString("Photo", "p1");

            CookieOptions options = new CookieOptions();
            options.Expires = DateTime.Now.AddYears(100);

            Response.Cookies.Append("IsDarkMode", Value, options);
            TempData["IsDarkMode"] = Value;

            return RedirectToAction("Index", "Home");
        }


        public IActionResult Index()
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if(IsDarkModeCookie == null)
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

            return View(new List<Book>());
        }

        public IActionResult News()
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

            return View();
        }

        [HttpPost]
        public IActionResult Search(string SearchType, string Query)
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

            TempData["SearchQuery"] = Query;
            TempData["IsDarkMode"] = IsDarkModeCookie;

            //List<Book> AllBooks = Context.Books.ToList();
            List<Book> AllBooks = new List<Book>();
            List<Book> SearchBooks = new List<Book>();

            foreach(Book CurrentBook in AllBooks)
            {
                if(SearchType == "All")
                {
                    if(CurrentBook.Title.Contains(Query))
                        SearchBooks.Add(CurrentBook);
                    else if(CurrentBook.Description.Contains(Query))
                        SearchBooks.Add(CurrentBook);
                    else if(CurrentBook.Author.Contains(Query))
                        SearchBooks.Add(CurrentBook);
                }
                else
                {
                    if(SearchType == "Title")
                    {
                        if(CurrentBook.Title.Contains(Query))
                            SearchBooks.Add(CurrentBook);
                    }
                    else if(SearchType == "Author")
                    {
                        if(CurrentBook.Author.Contains(Query))
                            SearchBooks.Add(CurrentBook);
                    }
                    else if(SearchType == "Description")
                    {
                        if(CurrentBook.Description.Contains(Query))
                            SearchBooks.Add(CurrentBook);
                    }
                }
            }

            return View(SearchBooks);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
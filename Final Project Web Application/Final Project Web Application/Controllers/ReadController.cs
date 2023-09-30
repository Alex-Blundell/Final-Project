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
            List<Book> RAWBookList = Context.Books.ToList(); // Get Book Data from the DB Context.
            List<Book> BookList = new List<Book>(); // Edited Book List.

            if(Genre != null)
            {
                foreach(Book ThisBook in RAWBookList)
                {
                    if(ThisBook.Genre == Book.Category.ActionAdventure && Genre == "ActionAdventure")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if(ThisBook.Genre == Book.Category.Classic && Genre == "Classic")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Crime && Genre == "Crime")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Drama && Genre == "Drama")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Fantasy && Genre == "Fantasy")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Horror && Genre == "Horror")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Mystery && Genre == "Mystery")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Non_Fiction && Genre == "Non-Fiction")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Romance && Genre == "Romance")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Satire && Genre == "Satire")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Sci_Fi && Genre == "Sci-Fi")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Thriller && Genre == "Thriller")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Western && Genre == "Western")
                    {
                        BookList.Add(ThisBook);
                    }
                    else if (ThisBook.Genre == Book.Category.Young_Adult && Genre == "YoungAdult")
                    {
                        BookList.Add(ThisBook);
                    }
                }
            }

            // Send BookList to the View.
            return View(BookList);
        }
    }
}

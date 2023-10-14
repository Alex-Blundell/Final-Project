using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly ApplicationDBContext Context;

        public AdminPanelController(ApplicationDBContext DBContext)
        {
            Context = DBContext;
        }

        public IActionResult Index()
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

            TempData["IsDarkMode"] = IsDarkModeCookie;

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;

                Models.User SelectedUser = null;
                bool FoundUserID = false;

                foreach(Models.User CurrentUser in Context.Users)
                {
                    if(CurrentUser.ID == int.Parse(UserID))
                    {
                        FoundUserID = true;
                        SelectedUser = CurrentUser;
                    }
                }

                if(FoundUserID)
                {
                    if (SelectedUser.SecLevel >= Models.User.SecurityLevel.Admin)
                    {
                        IEnumerable<Book> BookList = Context.Books;
                        return View(BookList);
                    }
                    else
                        return RedirectToAction("Index", "Home"); // Saved UserID does not have a security level high enough to view the Administration Panel.
                }
                else
                {
                    // Did not Find User ID saved in Cookies, Incorrect User ID, redirect to Home Index.
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Currently Not Logged in, as such they should not be able to access the Admin Panel.
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult AddBook()
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

                Models.User SelectedUser = null;
                bool FoundUserID = false;

                foreach (Models.User CurrentUser in Context.Users)
                {
                    if (CurrentUser.ID == int.Parse(UserID))
                    {
                        FoundUserID = true;
                        SelectedUser = CurrentUser;
                    }
                }

                if (FoundUserID)
                {
                    if (SelectedUser.SecLevel >= Models.User.SecurityLevel.Admin)
                    {
                        TempData["IsDarkMode"] = IsDarkModeCookie;
                        return View();
                    }
                    else
                        return RedirectToAction("Index", "Home"); // Saved UserID does not have a security level high enough to view the Administration Panel.
                }
                else
                {
                    // Did not Find User ID saved in Cookies, Incorrect User ID, redirect to Home Index.
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Currently Not Logged in, as such they should not be able to access the Admin Panel.
                return RedirectToAction("Index", "Home");
            }
        }

        [HttpPost]
        public IActionResult AddBook(Book NewBook)
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

                Models.User SelectedUser = null;
                bool FoundUserID = false;

                foreach (Models.User CurrentUser in Context.Users)
                {
                    if (CurrentUser.ID == int.Parse(UserID))
                    {
                        FoundUserID = true;
                        SelectedUser = CurrentUser;
                    }
                }

                if (FoundUserID)
                {
                    if (SelectedUser.SecLevel >= Models.User.SecurityLevel.Admin)
                    {
                        TempData["IsDarkMode"] = IsDarkModeCookie;

                        Context.Books.Add(NewBook);
                        Context.SaveChanges();
                        return RedirectToAction("Index", "AdminPanel");
                    }
                    else
                        return RedirectToAction("Index", "Home"); // Saved UserID does not have a security level high enough to view the Administration Panel.
                }
                else
                {
                    // Did not Find User ID saved in Cookies, Incorrect User ID, redirect to Home Index.
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Currently Not Logged in, as such they should not be able to access the Admin Panel.
                return RedirectToAction("Index", "Home");
            }
        }

        public IActionResult Delete(int ID)
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

            TempData["IsDarkMode"] = IsDarkModeCookie;

            Book SelectedBook = Context.Books.FirstOrDefault(b => b.ID == ID);

                if (SelectedBook != null)
                {
                    Context.Books.Remove(SelectedBook);
                    Context.SaveChanges();
                }

                return RedirectToAction("Index");
            }

        

        public IActionResult EditBook(int ID)
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

                Models.User SelectedUser = null;
                bool FoundUserID = false;

                foreach (Models.User CurrentUser in Context.Users)
                {
                    if (CurrentUser.ID == int.Parse(UserID))
                    {
                        FoundUserID = true;
                        SelectedUser = CurrentUser;
                    }
                }

                if (FoundUserID)
                {
                    if (SelectedUser.SecLevel >= Models.User.SecurityLevel.Admin)
                    {
                        TempData["IsDarkMode"] = IsDarkModeCookie;
                        return View();
                    }
                    else
                        return RedirectToAction("Index", "Home"); // Saved UserID does not have a security level high enough to view the Administration Panel.
                }
                else
                {
                    // Did not Find User ID saved in Cookies, Incorrect User ID, redirect to Home Index.
                    return RedirectToAction("Index", "Home");
                }
            }
            else
            {
                // Currently Not Logged in, as such they should not be able to access the Admin Panel.
                return RedirectToAction("Index", "Home");
            }
        }
    }
}

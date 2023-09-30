using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ApplicationDBContext Context;

        public ProfileController(ApplicationDBContext DBContext)
        {
            Context = DBContext;
        }

        public IActionResult Index(string Username)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
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

                // If the User that has the UserID Username Matches the Incoming Username then it is clearly my own Profile.
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }

        [HttpPost]
        public IActionResult Index(string Username, string Password)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
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

                // If the User that has the UserID Username Matches the Incoming Username then it is clearly my own Profile.
            }

            User SelectedUser = null;
            int ID = int.Parse(UserID);

            foreach(User CurrentUser in Context.Users)
            {
                if(CurrentUser.ID == ID)
                {
                    SelectedUser = CurrentUser;
                }
            }

            bool FoundError = false;

            // Changes have been Made to the Username, Update it in DB.
            if (SelectedUser.Username != Username)
            {
                foreach(Models.User CurrentUser in Context.Users)
                {
                    if(CurrentUser.Username == Username)
                    {
                        FoundError = true;
                    }
                }

                if(FoundError)
                {
                    // Show Error on WebPage
                }
                else
                {
                    SelectedUser.Username = Username;
                    Context.Update(SelectedUser);
                    Context.SaveChanges();
                }
            }

            if(!FoundError)
            {
                // Changes have been made to the Password, Update it in the DB.
                SelectedUser.Password = Models.User.EncryptString(Password);
                Context.Update(SelectedUser);
                Context.SaveChanges();
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;
            return View();
        }

        public IActionResult ReadList(int ID)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
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

                // If the User that has the UserID Username Matches the Incoming Username then it is clearly my own Profile.
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View(new List<Book>());
        }

        public IActionResult BorrowedItems(int ID)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
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

                // If the User that has the UserID Username Matches the Incoming Username then it is clearly my own Profile.
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            int UID = int.Parse(UserID);

            // Get All Borrowed Books.
            //List<BorrowedBook> BorrowedBook = Context.BorrowedBooks.ToList();
            List<BorrowedBook> BorrowedBook = new List<BorrowedBook>();
            List<BorrowedBook> MyBooks = new List<BorrowedBook>();

            foreach(BorrowedBook CurrentBook in BorrowedBook)
            {
                if(CurrentBook.BorrowerID == UID)
                {
                    MyBooks.Add(CurrentBook);
                }
            }

            return View(MyBooks);
        }

        public IActionResult Settings(int ID)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
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

                // If the User that has the UserID Username Matches the Incoming Username then it is clearly my own Profile.
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }
    }
}

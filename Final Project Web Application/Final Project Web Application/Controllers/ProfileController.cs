using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Default Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;
            ViewData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }

        public IActionResult ReadList()
        {
            return View();
        }

        public IActionResult BorrowedItems()
        {
            return View();
        }

        public IActionResult Settings()
        {
            return View();
        }
    }
}

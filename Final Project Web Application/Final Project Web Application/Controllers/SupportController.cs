using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class SupportController : Controller
    {
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

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                ViewData["HasLoggedIn"] = HasLoggedIn;
                ViewData["UserID"] = UserID;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;
            ViewData["IsDarkMode"] = IsDarkModeCookie;


            return View();
        }
    }
}

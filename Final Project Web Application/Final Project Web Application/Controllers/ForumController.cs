using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ForumController : Controller
    {
        private readonly ApplicationDBContext Context;

        public ForumController(ApplicationDBContext DBContext)
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

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                ViewData["HasLoggedIn"] = HasLoggedIn;
                ViewData["UserID"] = UserID;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            IEnumerable<Forum> ForumObjList = Context.Forums;
            return View(ForumObjList);
        }

        public IActionResult Forum()
        {
            IEnumerable<Models.Thread> ThreadObjList = Context.Threads;
            return View(ThreadObjList);

        }

        public IActionResult Thread()
        {
            return View();
        }

        public IActionResult NewThread()
        {
            return View();
        }

        public IActionResult NewPost()
        {
            return View();
        }
    }
}

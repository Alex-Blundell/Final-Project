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

        public IActionResult Index(string Name)
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

            if(Name != null)
            {
                TempData["IsThreads"] = "Yes";
                IEnumerable<Models.Thread> ThreadObjList = Context.Threads;

                int SelectedID = 0;

                if (Name == "Introductions")
                {
                    SelectedID = 1;
                }
                else if (Name == "Help")
                {
                    SelectedID = 10;
                }
                else if (Name == "General")
                {
                    SelectedID = 11;
                }
                else if (Name == "Off_Topic")
                {
                    SelectedID = 12;
                }
                else if (Name == "Suggestions")
                {
                    SelectedID = 13;
                }
                else if (Name == "Recomendations")
                {
                    SelectedID = 14;
                }
                else if (Name == "Forgot_Title")
                {
                    SelectedID = 15;
                }
                else if (Name == "Reviews")
                {
                    SelectedID = 16;
                }
                else
                {
                    TempData["IsThreads"] = "No";
                    IEnumerable<Forum> ForumObjList = Context.Forums;
                    return View(ForumObjList);
                }

                List<Models.Thread> ThreadList = ThreadObjList.Where(x => x.ID == SelectedID).ToList();

                ViewBag.Model = ThreadList;
                return View();
            }
            else
            {
                TempData["IsThreads"] = "No";
                IEnumerable<Forum> ForumObjList = Context.Forums;

                return View(ForumObjList);
            }
        }

        public IActionResult Thread(int ID)
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

            return View();
        }

        public IActionResult NewThread()
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

            return View();
        }

        public IActionResult NewPost()
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

            return View();
        }
    }
}
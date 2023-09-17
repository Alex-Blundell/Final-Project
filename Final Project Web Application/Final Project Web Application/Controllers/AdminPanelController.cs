using Final_Project_Web_Application.Data;
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
                ViewData["HasLoggedIn"] = HasLoggedIn;
                ViewData["UserID"] = UserID;
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
                        return View();
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

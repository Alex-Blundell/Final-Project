using Final_Project_Web_Application.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Final_Project_Web_Application.Controllers
{
    public class LoginController : Controller
    {
        private readonly ApplicationDBContext Context;

        public LoginController(ApplicationDBContext DBContext)
        {
            Context = DBContext;
        }

        public IActionResult Index()
        {
            string LoginCookie = Request.Cookies["HasLoggedIn"];
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

            if (LoginCookie != null)
            {
                TempData["HasLoggedIn"] = LoginCookie;

                if(LoginCookie == "Yes")
                {
                    string UserIDCookie = Request.Cookies["UserID"];
                    TempData["UserID"] = UserIDCookie;

                    return RedirectToAction("Index", "Home");
                }
            }

            return View();
        }

        [HttpPost]
        public IActionResult Index(string Username, string Password, bool RememberMe)
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

            Models.User SelectedUser = new Models.User();
            bool FoundUser = false;

            if(Username.IsNullOrEmpty())
                FoundUser = false;
            else if (Password.IsNullOrEmpty())
                FoundUser = false;
            else
            {
                foreach (Models.User CurrentUser in Context.Users)
                {
                    if (CurrentUser.Username == Username)
                    {
                        string DecryptedPassword = Models.User.DecryptString(CurrentUser.Password);

                        // Check Password against the Decrypted Password.
                        if (DecryptedPassword == Password)
                        {
                            FoundUser = true;
                            SelectedUser = CurrentUser;
                        }
                    }
                }
            }

            if (FoundUser)
            {
                if(RememberMe)
                {
                    CookieOptions Options = new CookieOptions();
                    Options.Expires = DateTime.Now.AddYears(100);

                    Response.Cookies.Append("HasLoggedIn", "Yes", Options);
                    Response.Cookies.Append("UserID", SelectedUser.ID.ToString(), Options);
                }
                else
                {
                    TempData["TempLogin"] = "Yes";
                    TempData["TempUserID"] = SelectedUser.ID.ToString();
                }

                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }
        }

        public IActionResult SignUp()
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

        [HttpPost]
        public IActionResult SignUp(string Username, string Password)
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

            // Possibly Switch Username up for Email.

            bool SignedUp = true;

            foreach(Models.User CurrentUser in Context.Users)
            {
                // An Account already exists with that Username.
                if (CurrentUser.Username == Username)
                    SignedUp = false;
                else if (CurrentUser.Username.ToLower() == Username.ToLower())
                    SignedUp = false;
            }

            // Check to See if Password is Less than Least Ammount of Characters.

            if (SignedUp)
            {
                string EncryptedPassword = Models.User.EncryptString(Password);

                Context.Users.Add(new Models.User(Username, EncryptedPassword, Models.User.SecurityLevel.User));
                Context.SaveChanges();

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View();
            }
        }

        public IActionResult ForgotPassword()
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

        public IActionResult SignOut()
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

            // Code for Signing Out.
            string cookieValue = Request.Cookies["HasLoggedIn"];

            if (cookieValue != null)
            {
                if (cookieValue == "Yes")
                {
                    Response.Cookies.Delete("HasLoggedIn");
                    Response.Cookies.Delete("UserID");
                    return RedirectToAction("Index", "Login");
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Not Needed once I figure out how to remove button on Runtime.
                }
            }
            else
            {
                return RedirectToAction("Index", "Home"); // Not Needed once I figure out how to remove button on Runtime.
            }
        }

        public IActionResult GoogleLogin()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult FacebookLogin()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult MicrosoftLogin()
        {
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AppleLogin()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
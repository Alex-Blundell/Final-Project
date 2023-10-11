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
            // Get the value of the IsDarkMode cookie from the request
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];

            // Check if the IsDarkMode cookie is null (first-time website run), and set it to the default value "No"
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            // Set the IsDarkMode value in TempData for use in the view
            TempData["IsDarkMode"] = IsDarkModeCookie;

            // Clear previous error messages from TempData
            TempData["ErrorMessage"] = null;

            // Check if either the Username or Password is blank
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                // Set an error message in TempData for display in the view
                TempData["ErrorMessage"] = "Username and Password are required.";
                return View();
            }
            else
            {
                // Create a new user object to store the selected user
                Models.User SelectedUser = new Models.User();
                // Flag to track whether a user with the provided credentials is found
                bool FoundUser = false;

                // Loop through each user in the database
                foreach (Models.User CurrentUser in Context.Users)
                {
                    // Check if the current user's username matches the provided username
                    if (CurrentUser.Username == Username)
                    {
                        // Decrypt the password for comparison
                        string DecryptedPassword = Models.User.DecryptString(CurrentUser.Password);

                        // Check if the decrypted password matches the provided password
                        if (DecryptedPassword == Password)
                        {
                            // Set FoundUser to true and store the selected user
                            FoundUser = true;
                            SelectedUser = CurrentUser;
                        }
                    }
                }

                // Check if a user with the provided credentials is found
                if (FoundUser)
                {
                    // If RememberMe is true, set cookies for HasLoggedIn and UserID
                    if (RememberMe)
                    {
                        CookieOptions Options = new CookieOptions();
                        Options.Expires = DateTime.Now.AddYears(100);

                        Response.Cookies.Append("HasLoggedIn", "Yes", Options);
                        Response.Cookies.Append("UserID", SelectedUser.ID.ToString(), Options);
                    }
                    else
                    {
                        // If RememberMe is false, store temporary login information in TempData
                        TempData["TempLogin"] = "Yes";
                        TempData["TempUserID"] = SelectedUser.ID.ToString();
                    }

                    // Redirect to the home page
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    // If no user is found, set an error message for display in the view
                    TempData["ErrorMessage"] = "Invalid username or password.";
                    return View();
                }
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

            // Check if either the Username or Password is blank
            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                // Set an error message in TempData for display in the view
                TempData["ErrorMessage"] = "Username and Password are required.";
                return View();
            }

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

                Context.Users.Add(new Models.User(Username, EncryptedPassword, Models.User.SecurityLevel.User, "\\css\\avatars\\default.jpg"));
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
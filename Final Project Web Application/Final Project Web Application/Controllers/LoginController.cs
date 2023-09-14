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

        public string Username { get; set; }
        public string Password { get; set; }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string Username, string Password, bool RememberMe)
        {
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
                        }
                    }
                }
            }

            if (FoundUser)
            {
                // Check Out Session Keys and Cookies as a way to make the Website remember me next Time.
                if(RememberMe)
                {

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
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(string Username, string Password)
        {
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
            return View();
        }

        public IActionResult SignOut()
        {
            // Code for Signing Out.
            return RedirectToAction("Index", "Home");
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
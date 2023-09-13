using Final_Project_Web_Application.Data;
using Microsoft.AspNetCore.Mvc;

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
        public IActionResult Index(string Username, string Password)
        {
            bool FoundUser = false;

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

            if (FoundUser)
            {
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
            bool SignedUp = true;

            foreach(Models.User CurrentUser in Context.Users)
            {
                // An Account already exists with that Username.
                if (CurrentUser.Username == Username)
                    SignedUp = false;
            }

            if(SignedUp)
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
    }
}
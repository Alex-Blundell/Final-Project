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

            foreach(Models.User CurrentUser in Context.Users)
            {
                if(CurrentUser.Username == Username)
                {
                    string DecryptedPassword = "";

                    // Check Password against the Decrypted Password.
                    if(CurrentUser.Password == Password)
                    {
                        FoundUser = true;
                    }
                }
            }

            if(FoundUser)
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

        public IActionResult ForgotPassword()
        {
            return View();
        }

        public void TestOne()
        {

        }
        
    }
}
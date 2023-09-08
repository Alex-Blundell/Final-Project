using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ForumController : Controller
    {
        public IActionResult ForumsOverview()
        {
            return View();
        }

        public IActionResult Forum()
        {
            return View();
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

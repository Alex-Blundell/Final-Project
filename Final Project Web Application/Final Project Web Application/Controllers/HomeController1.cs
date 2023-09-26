using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class HomeController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

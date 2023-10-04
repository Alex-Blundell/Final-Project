using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class UserUnitTestController : Controller
    {
        public List<User> GetUserList()
        {
            return new List<User>
        {
            new User
            {
                ID = 1,
                Username = "John Smith",
                Password = "qwe123"
            },
            new User
             {
                 ID = 2,
                 Username = "Cindy Huong",
                 Password = "qwe123"
             },

            new User
             {
                 ID = 3,
                 Username = "Jana Price",
                 Password = "qwe123"
             },
            };
        }

        public IActionResult Index()
        {
            var users = from u in GetUserList()
                        select u;
            return View(users);

        }
        public IActionResult User()
        {
            var users = from e in GetUserList()
                        orderby e.ID
                        select e;
            return View(users);
        }
        public IActionResult Details(int id)
        {
            return View(Details);
        }
    
    }
}

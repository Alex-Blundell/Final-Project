using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using static Final_Project_Web_Application.Models.Book;

namespace Final_Project_Web_Application.Controllers
{
    public class ForumUnitTestController : Controller
    {
        public List<Forum> GetForumList()
        {
            return new List<Forum>
            {
                new Forum
                {
                    ID = 1,
                    Name = "Visor",
                    Description = "This is nice web app ",
                },

                new Forum
                {
                    ID = 2,
                    Name = "Reader 1",
                    Description = "I like this book. And this is nice web app ",
                },
                new Forum
                {
                    ID = 3,
                    Name = "Visor 2",
                    Description = "This is nice web app ",
                },
            };
        }

        public IActionResult Index()
        {
            var forums = from f in GetForumList()
                        select f;
            return View(forums);

        }
        public IActionResult forums()
        {
            var forums = from f in GetForumList()
                        orderby f.ID
                        select f;
            return View(forums);
        }
        public IActionResult Details(int id)
        {
            return View(Details);
        }

    }
}

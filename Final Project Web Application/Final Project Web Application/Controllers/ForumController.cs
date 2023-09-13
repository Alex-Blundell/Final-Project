using Final_Project_Web_Application.Data;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;

namespace Final_Project_Web_Application.Controllers
{
    public class ForumController : Controller
    {
        private readonly ApplicationDBContext Context;

        public ForumController(ApplicationDBContext DBContext)
        {
            Context = DBContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Forum> ForumObjList = Context.Forums;
            return View(ForumObjList);
        }

        public IActionResult Forum()
        {
            IEnumerable<Models.Thread> ThreadObjList = Context.Threads;
            return View(ThreadObjList);

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

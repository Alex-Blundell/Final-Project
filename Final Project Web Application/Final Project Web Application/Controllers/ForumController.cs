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

        public IActionResult Index(string Name)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            if(Name != null)
            {
                TempData["IsThreads"] = "Yes";
                IEnumerable<Models.Thread> ThreadObjList = Context.Threads;

                int SelectedID = 0;

                if (Name == "Introductions")
                {
                    SelectedID = Context.Forums.ToList()[0].ID;
                }
                else if (Name == "Help")
                {
                    SelectedID = Context.Forums.ToList()[1].ID;
                }
                else if (Name == "General")
                {
                    SelectedID = Context.Forums.ToList()[2].ID;
                }
                else if (Name == "Off Topic")
                {
                    SelectedID = Context.Forums.ToList()[3].ID;
                }
                else if (Name == "Suggestions")
                {
                    SelectedID = Context.Forums.ToList()[4].ID;
                }
                else if (Name == "Recomendations")
                {
                    SelectedID = Context.Forums.ToList()[5].ID;
                }
                else if (Name == "I Forgot the Title...")
                {
                    SelectedID = Context.Forums.ToList()[6].ID;
                }
                else if (Name == "Reviews")
                {
                    SelectedID = Context.Forums.ToList()[7].ID;
                }
                else
                {
                    TempData["IsThreads"] = "No";
                    IEnumerable<Forum> ForumObjList = Context.Forums;
                    return View(ForumObjList);
                }

                List<Models.Thread> ThreadList = ThreadObjList.Where(x => x.ID == SelectedID).ToList();

                ViewBag.Model = ThreadList;
                return View();
            }
            else
            {
                TempData["IsThreads"] = "No";
                IEnumerable<Forum> ForumObjList = Context.Forums;

                return View(ForumObjList);
            }
        }

        public IActionResult Thread(int ID)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }

        public IActionResult NewThread()
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }

        [HttpPost]
        public IActionResult NewThread(string Name, string Message)
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            // New Thread.
            Models.Thread NewThread = new Models.Thread();

            NewThread.Name = Name;
            NewThread.ForumID = 0;
            NewThread.CreationDate = DateTime.Now.ToString();

            Context.Threads.Add(NewThread);
            Context.SaveChanges();

            // New Post.
            IEnumerable<Models.Thread> AllThreads = Context.Threads;

            Post NewPost = new Post();

            NewPost.ThreadID = AllThreads.Last().ID;

            NewPost.Title = Name;
            NewPost.Message = Message;
            NewPost.PostNum = 1;
            NewPost.PostDateTime = AllThreads.Last().CreationDate;

            NewPost.UserID = int.Parse(UserID);
            NewPost.WasEdited = false;
            
            Context.Posts.Add(NewPost);
            Context.SaveChanges();
            
            return View();
        }

        public IActionResult NewPost()
        {
            string IsDarkModeCookie = Request.Cookies["IsDarkMode"];
            string UserID = Request.Cookies["UserID"];
            string HasLoggedIn = Request.Cookies["HasLoggedIn"];

            // Probably the First time the Website has been Run, Add Cookie for Dark Mode and Set it to the Defualt Value.
            if (IsDarkModeCookie == null)
            {
                CookieOptions Options = new CookieOptions();
                Options.Expires = DateTime.Now.AddYears(100);

                IsDarkModeCookie = "No";
                Response.Cookies.Append("IsDarkMode", IsDarkModeCookie, Options);
            }

            if (HasLoggedIn == "Yes")
            {
                TempData["HasLoggedIn"] = HasLoggedIn;
                TempData["UserID"] = UserID;
            }

            TempData["IsDarkMode"] = IsDarkModeCookie;

            return View();
        }
    }
}
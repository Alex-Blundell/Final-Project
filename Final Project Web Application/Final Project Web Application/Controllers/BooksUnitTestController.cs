using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using static Final_Project_Web_Application.Models.Book;

namespace Final_Project_Web_Application.Controllers
{
    public class BooksUnitTestController : Controller
    {
        public List<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book
                {
                    ID = 1,
                    Title = "Test Book1",
                    Description = "This is a noval",
                    Author = "John Smith",
                    CoverURL = "http://testing@google.com",
                    Genre = Category.Drama,
                    Status = BorrowedStatus.Available,

                },
                new Book
                {
                    ID = 2,
                    Title = "Test Book2",
                    Description = "This is a noval",
                    Author = "Lucy Smith",
                    CoverURL = "http://testing@google.com",
                    Genre = Category.Classic,
                    Status = BorrowedStatus.Available,

                },
                new Book
                {
                    ID = 3,
                    Title = "Test Book3",
                    Description = "This is a noval",
                    Author = "Smith Asdhe",
                    CoverURL = "http://testing@google.com",
                    Genre = Category.Crime,
                    Status = BorrowedStatus.Borrowed,

                },

            };
        }

        public IActionResult Index()
        {
            var books = from b in GetBookList()
                        select b;
            return View(books);

        }
        public IActionResult books()
        {
            var books = from e in GetBookList()
                        orderby e.ID
                        select e;
            return View(books);
        }
        public IActionResult Details(int id)
        {
            return View(Details);
        }

    }
}

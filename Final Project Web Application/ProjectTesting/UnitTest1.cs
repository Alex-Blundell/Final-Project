using Final_Project_Web_Application.Controllers;
using Final_Project_Web_Application.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ProjectTesting
{
    [TestClass]
    public class LoginUnitTest
    {
        // Test method for testing the UserName property
        [TestMethod]
        public void TestLogin_UserName()
        {
            User u = new User();
            u.Username = "ABC";
            Assert.AreEqual("ABC", u.Username);

        }
        // Test method for testing the Password property
        [TestMethod]
        public void TestLogin_Password()
        {
            User u = new User();
            u.Password = "ABC123";
            Assert.AreEqual("ABC123", u.Password);
        }
    }


    [TestClass]
    public class RegistreUnitTest
    {
        // Test method for testing the UserName property
        [TestMethod]
        public void TestRegister_UserName()
        {
            User u = new User();
            u.Username = "ABC";
            Assert.AreEqual("ABC", u.Username);

        }
        // Test method for testing the UserPassword property
        [TestMethod]
        public void TestRegister_UserPassword()
        {
            User u = new User();
            u.Password = "ABC123";
            Assert.AreEqual("ABC123", u.Password);

        }
    
    }

    [TestClass]
    public class BooksUnitTest
    {
        [TestMethod]
        public void Books_AuthorTest1()
        {
            Book b = new Book();
            b.Author = "TESTING";
            Assert.AreEqual("TESTING", b.Author);
        }
        [TestMethod]
        public void Books_TitleTest3()
        {
            Book b = new Book();
            b.Title = "TESTING";
            Assert.AreEqual("TESTING", b.Title);
        }
        [TestMethod]
        public void Books_DescriptionTest4()
        {
            Book b = new Book();
            b.Description = "TESTING";
            Assert.AreEqual("TESTING", b.Description);
        }
        [TestMethod]
        public void Books_CoverUrlTest5()
        {
            Book b = new Book();
            b.CoverURL = "http://testing.com";
            Assert.AreEqual("http://testing.com", b.CoverURL);
        }
        [TestMethod]
        public void Books_GenreTest6()
        {
            Book b = new Book();
            b.Genre = Book.Category.Classic;
            Assert.AreEqual(Book.Category.Classic, b.Genre);
        }
    }


    [TestClass]
    public class SearchUnitTest
    {
        [TestMethod]
        public void TestSearch_All()
        {

            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook2.Title = "The Great Gatsby";
            testBook2.Author = "F. Scott Fitzgerald";
            testBook2.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook3.Title = "The Catcher in the Rye";
            testBook3.Author = "J.D. Salinger";
            testBook3.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";


            // Create a list of books
            List<Book> bookList = new List<Book>
                {
                    testBook1,
                    testBook2,
                    testBook3,
                };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByAll(bookList, "Harry");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found

        }

        [TestMethod]
        public void TestSearch_Title()
        {

            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook2.Title = "The Great Gatsby";
            testBook2.Author = "F. Scott Fitzgerald";
            testBook2.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook3.Title = "The Catcher in the Rye";
            testBook3.Author = "J.D. Salinger";
            testBook3.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";


            // Create a list of books
            List<Book> bookList = new List<Book>
                {
                    testBook1,
                    testBook2,
                    testBook3,
                };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByTitle(bookList, "Harry");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found

        }
        [TestMethod]
        public void TestSearch_Author()
        {

            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook2.Title = "The Great Gatsby";
            testBook2.Author = "F. Scott Fitzgerald";
            testBook2.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook3.Title = "The Catcher in the Rye";
            testBook3.Author = "J.D. Salinger";
            testBook3.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";


            // Create a list of books
            List<Book> bookList = new List<Book>
                {
                    testBook1,
                    testBook2,
                    testBook3,
                };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByAuthor(bookList, "F");

            // Assert the expected results
            CollectionAssert.DoesNotContain(searchResults, testBook1); // Harry Potter book should not be found 
            CollectionAssert.Contains(searchResults, testBook2); // The Great Gatsby should be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found

        }

        [TestMethod]
        public void TestSearch_Description()
        {

            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook2.Title = "The Great Gatsby";
            testBook2.Author = "F. Scott Fitzgerald";
            testBook2.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook3.Title = "The Catcher in the Rye";
            testBook3.Author = "J.D. Salinger";
            testBook3.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";


            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
            };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByDescription(bookList, "Harry Potter");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found

        }
    }

    [TestClass]
    public class ForumUnitTest
    {
        // Test method for testing the forum function
        [TestMethod]
        public void TestForumNameTest()
        {
            Forum f = new Forum();
            f.Name = "Test1";
            Assert.AreEqual("Test1", f.Name);

        }
        [TestMethod]
        public void ForumDescriptionTest()
        {
            Forum f = new Forum();
            f.Description = "Testing Case";
            Assert.AreEqual("Testing Case", f.Description);

        }
    }

    [TestClass]
    public class PostUnitTest
    {
        // Test method for testing the post function
        [TestMethod]
        public void Post_NameTest()
        {
            Post p = new Post();
            p.Title = "Sharing";
            Assert.AreEqual("Sharing", p.Title);

        }
        [TestMethod]
        public void Post_MessageTest()
        {
            Post p = new Post();
            p.Message = "Sharing";
            Assert.AreEqual("Sharing", p.Message);
        }

        [TestMethod]
        public void Post_DateTest()
        {
            Post p = new Post();
            p.PostDateTime = "20/09/2020";
            Assert.AreEqual("20/09/2020", p.PostDateTime);
        }
    }


    [TestClass]
    public class ForumThreadTest
    {
        [TestMethod]
        public void Thread_NameTest()
        {
            Final_Project_Web_Application.Models.Thread t = new Final_Project_Web_Application.Models.Thread();

            t.Name = "Thread";
            Assert.AreEqual("Thread", t.Name);
        }
        [TestMethod]
        public void Thread_CreationDateTest()
        {
            Final_Project_Web_Application.Models.Thread t = new Final_Project_Web_Application.Models.Thread();
            t.CreationDate = "02/10/2023";
            Assert.AreEqual("02/10/2023", t.CreationDate);

        }

    }


    [TestClass]
    public class ControllerUnitTest
    {
        [TestMethod]
        public void UserControllerUnitTest()
        {
            UserUnitTestController controller = new UserUnitTestController();
            IActionResult result = controller.Index() as IActionResult;
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void BooksControllerUnitTest()
        {
            BooksUnitTestController controller = new BooksUnitTestController();
            IActionResult result = controller.Index() as IActionResult;
            Assert.IsNotNull(result);
        }
        [TestMethod]
        public void ForumControllerUnitTest()
        {
            ForumUnitTestController controller = new ForumUnitTestController();
            IActionResult result = controller.Index() as IActionResult;
            Assert.IsNotNull(result);
        }



    }
}
using Final_Project_Web_Application.Models;

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


        // Test method for testing the RememberMe property
        [TestMethod]
        public void TestLogin_RememberMe()
        {
            /*
            User u = new User();
            u.R = true; // Simulate checking the "Remember Me" checkbox
            Assert.IsTrue(u.RememberMe, "RememberMe should be true when the checkbox is checked.");
            */
        }



        // Test method for testing the login functionality
        [TestMethod]
        public void TestLogin_LoginButton()
        {
            // Simulate clicking the login button
            /*
            User u = new User();
            bool loginSuccessful = u.Login(); // Assuming Login() method returns a boolean indicating success

            // Assert
            Assert.IsTrue(loginSuccessful, "Login should be successful when valid credentials are used.");
            */
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


        // Test method for testing the registration functionality
        [TestMethod]
        public void TestRegister_RegisterButton()
        {
            /*
            // Simulate clicking the Register button
            User u = new User();
            bool registerSuccessful = u.Register(); // Assuming Register() method returns a boolean indicating success

            // Assert
            Assert.IsTrue(registerSuccessful, "Registeration should be successful when valid credentials are used.");
            */
        }

    }

    [TestClass]
    public class HomePageUnitTest
    {
        [TestMethod]
        public void HomePageTestMethod1()
        {
        }

        [TestMethod]
        public void ClickHomeButton_ShouldShowHomePage()
        {
            // Arrange
            MainLayout mainLayout = new MainLayout();

            // Act
            mainLayout.ClickHomeButton();

            // Assert
            // Assuming there's some property or method to check if the home page is visible
            Assert.IsTrue(mainLayout.IsHomePageVisible(), "Home page should be visible after clicking the home button");
        }

        private class MainLayout
        {
            public MainLayout()
            {
            }

            internal void ClickHomeButton()
            {
                throw new NotImplementedException();
            }

            internal bool IsHomePageVisible()
            {
                throw new NotImplementedException();
            }
        }
    }

    [TestClass]
    public class BookCatalogueUnitTest
    {
        [TestMethod]
        public void BookCatalogueTestMethod1()
        {
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

        /*
    
        [TestMethod]
        public void TestSearch_BookTitle()
        {    
            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook1.Title = "The Great Gatsby";
            testBook1.Author = "F. Scott Fitzgerald";
            testBook1.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook1.Title = "The Catcher in the Rye";
            testBook1.Author = "J.D. Salinger";
            testBook1.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";

            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
            };

            // Create a filter object
            var filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByBookTitle(bookList, "Harry");

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

            testBook1.Title = "The Great Gatsby";
            testBook1.Author = "F. Scott Fitzgerald";
            testBook1.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook1.Title = "The Catcher in the Rye";
            testBook1.Author = "J.D. Salinger";
            testBook1.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
                "that was partially published in serial form 1945–46 before being novelized in 1951.";

            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
            };

            // Create a filter object
            var filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByAuthorName(bookList, "J");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found
            
        }
        [TestMethod]
        public void TestSearch_Descreiption()
        {

            // Create some sample book objects
            Book testBook1 = new Book();
            Book testBook2 = new Book();
            Book testBook3 = new Book();

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";
            testBook1.Description = "The first novel in the Harry Potter series and Rowling's debut novel," +
                " it follows Harry Potter, a young wizard who discovers his magical heritage on his eleventh ";

            testBook1.Title = "The Great Gatsby";
            testBook1.Author = "F. Scott Fitzgerald";
            testBook1.Description = "The Great Gatsby is a 1925 novel by American writer F. Scott Fitzgerald.";

            testBook1.Title = "The Catcher in the Rye";
            testBook1.Author = "J.D. Salinger";
            testBook1.Description = "The Catcher in the Rye is an American novel by J. D. Salinger " +
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
    public class ReadListUnitTest
    {
        // Test method for testing the behavior of the "Read" button
        [TestMethod]
        public void TestReadButton_Click_DisplaysMenuWithOptions()
        {
            // Arrange
            var menuSystemMock = new Mock<IMenuSystem>();
            var menuHandler = new MenuHandler(menuSystemMock.Object);

            // Mock the behavior of the menu system when the "Read" button is clicked
            menuSystemMock.Setup(ms => ms.DisplayMenu(It.IsAny<string[]>()))
                .Returns(new string[] { "Action & Adventure", "Classic","Crime",
            "Drama", "Fantasy", "Honor", "Myster", "Non-Fiction", "Romance",
            "Satire", "Sci-Fi", "Thriller", "Western", "Young Adult" });

            // Act
            menuHandler.ClickReadButton();

            // Assert
            // Retrieve the actual menu options from the menu system or UI
            string[] actualOptions = menuHandler.GetDisplayedMenuOptions();

            // Define the expected options
            string[] expectedOptions = { "Action & Adventure", "Classic","Crime",
            "Drama", "Fantasy", "Honor", "Myster", "Non-Fiction", "Romance",
            "Satire", "Sci-Fi", "Thriller", "Western", "Young Adult" };

            // Use CollectionAssert to check if the actual options match the expected options
            CollectionAssert.AreEquivalent(expectedOptions, actualOptions);
        }
        */
       
    }

}
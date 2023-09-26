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
        public void TestSearch_BookTitle()
        {
            // Create some sample book objects
            /*Book testBook1 = new Book();
            Book testBook2 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            Book testBook3 = new Book("To Kill a Mockingbird", "Harper Lee");
            Book testBook4 = new Book("The Catcher in the Rye", "J.D. Salinger");

            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";

            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
                testBook4
            };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByBookTitle(bookList, "Harry");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook4); // The Catcher in the Rye should not be found
            */
        }
        [TestMethod]
        public void TestSearch_Author()
        {
            /*
            // Create some sample book objects
            Book testBook1 = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling");
            Book testBook2 = new Book("The Great Gatsby", "F. Scott Fitzgerald");
            Book testBook3 = new Book("To Kill a Mockingbird", "Harper Lee");
            Book testBook4 = new Book("The Catcher in the Rye", "J.D. Salinger");


            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";


            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
                testBook4
            };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByAuthorName(bookList, "J");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found
            CollectionAssert.Contain(searchResults, testBook4); // The Catcher in the Rye should be found
            */
        }
        [TestMethod]
        public void TestSearch_Details()
        {
            /*
            // Create some sample book objects
            Book testBook1 = new Book("Harry Potter and the Sorcerer's Stone", "J.K. Rowling", "Publish on 12/03/1990");
            Book testBook2 = new Book("The Great Gatsby", "F. Scott Fitzgerald", "Publish on 20/05/2000");
            Book testBook3 = new Book("To Kill a Mockingbird", "Harper Lee", "Publish on 12/07/2020");
            Book testBook4 = new Book("The Catcher in the Rye", "J.D. Salinger", "Publish on 09/08/2009");


            testBook1.Title = "Harry Potter and the Sorcerer's Stone";
            testBook1.Author = "J.K. Rowling";


            // Create a list of books
            List<Book> bookList = new List<Book>
            {
                testBook1,
                testBook2,
                testBook3,
                testBook4
            };

            // Create a filter object
            Filter filter = new Filter();

            // Perform the search for books with names containing "Harry"
            List<Book> searchResults = filter.SearchBooksByDetails(bookList, "1990");

            // Assert the expected results
            CollectionAssert.Contains(searchResults, testBook1); // Harry Potter book should be found 
            CollectionAssert.DoesNotContain(searchResults, testBook2); // The Great Gatsby should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook3); // To Kill a Mockingbird should not be found
            CollectionAssert.DoesNotContain(searchResults, testBook4); // The Catcher in the Rye should be found
            */
        }
    }

    [TestClass]
    public class ReadListUnitTest
    {
        /*
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
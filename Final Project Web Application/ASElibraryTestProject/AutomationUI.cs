using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASElibraryTestProject
{
    [TestClass]
    public class AutomationUI
    {
        private readonly IWebDriver _driver;

        public AutomationUI()
        {
<<<<<<< Updated upstream
            ChromeOptions Options = new ChromeOptions();
            Options.AddArgument("--start-maximized");
            _driver = new ChromeDriver(Options);
=======
            _driver = new ChromeDriver();
        }
        [TestMethod] 
        public void Registerpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");
            Assert.AreEqual("Register - Final Project Web Application", _driver.Title);
              
            _driver.Close();
>>>>>>> Stashed changes
        }
     
        [TestMethod]
        public void Registerwithuserdetail()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");
            Assert.AreEqual("Register - Final Project Web Application", _driver.Title);

            //Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("Eva");
            DelayForDemo();

            //Password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("123");
            DelayForDemo();

            //Sign up click
            _driver.FindElement(By.Name("RegisterBTN")).Submit();

            _driver.Close();

        }
<<<<<<< Updated upstream
   
=======

        [TestMethod]
        public void RegisterWithBlankPassword()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");

            // Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("some");
            DelayForDemo();

            // Password (leave blank)
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("");
            DelayForDemo();

            // Register button click
            _driver.FindElement(By.Name("RegisterBTN")).Submit();

            // Verify that an error message is displayed (you may need to adapt this based on your actual implementation)
            IWebElement errorMessage = _driver.FindElement(By.ClassName("error-message"));
            Assert.IsNotNull(errorMessage);
            Assert.IsTrue(errorMessage.Text.Contains("The password is required"));

            _driver.Close();
        }

        [TestMethod]
        public void RegisterWithBlankUsername()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");

            // Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys(" ");
            DelayForDemo();

            // Password (leave blank)
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("123");
            DelayForDemo();

            // Register button click
            _driver.FindElement(By.Name("RegisterBTN")).Submit();

            // Verify that an error message is displayed (you may need to adapt this based on your actual implementation)
            IWebElement errorMessage = _driver.FindElement(By.ClassName("error-message"));
            Assert.IsNotNull(errorMessage);
            Assert.IsTrue(errorMessage.Text.Contains("The Username is required"));

            _driver.Close();
        }
        [TestMethod]
        public void RegisterWithSpecialCharacters()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");

            // Username with special characters
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("$%&^^^");
            DelayForDemo();

            // Password with special characters
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("$%&^^^");
            DelayForDemo();

            // Register button click
            _driver.FindElement(By.Name("RegisterBTN")).Submit();

            _driver.Close();
        }

        [TestMethod]
        public void Loginpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login");
            Assert.AreEqual("Login - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
>>>>>>> Stashed changes
        [TestMethod]
        public void Loginwithuserdetail()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login");
            Assert.AreEqual("Login - Final Project Web Application", _driver.Title);

            //Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("Admin");
            DelayForDemo();

            //Password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("Admin");
            DelayForDemo();

            //remember me click
            _driver.FindElement(By.Name("RememberMe")).Click();

            //log in click
            _driver.FindElement(By.Name("LoginBTN")).Click();

            _driver.Close();

        }
        private static void DelayForDemo()
        {
            Thread.Sleep(1000);

        }
      
        [TestMethod]
        public void Forumspage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Forum");
            Assert.AreEqual("Forums - Final Project Web Application", _driver.Title);

            _driver.FindElement(By.Name("ForumsBTN")).Click();
            _driver.FindElement(By.Name("Introductions BTN")).Click();

            _driver.Close();
        }

        [TestMethod]
        public void Supportpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Support");
            Assert.AreEqual("- Final Project Web Application", _driver.Title);

            _driver.Close();
        }
       
        [TestMethod]
        public void LogintoProfilepage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login");

            //Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("Admin");
            DelayForDemo();

            //Password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("Admin");
            DelayForDemo();

            //remember me click
            _driver.FindElement(By.Name("RememberMe")).Click();

            //log in click
            _driver.FindElement(By.Name("LoginBTN")).Click();

            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();

            Actions builder = new Actions(_driver);

            builder.MoveToElement(_driver.FindElement(By.Name("ProfileDropdown"))).Perform();

            DelayForDemo();

            _driver.FindElement(By.Name("ProfileBTN")).Click();
            builder.MoveToElement(_driver.FindElement(By.Name("ProfileDropdown"))).Perform();
            DelayForDemo();

            _driver.FindElement(By.Name("ReadlistBTN")).Click();
            builder.MoveToElement(_driver.FindElement(By.Name("ProfileDropdown"))).Perform();
            DelayForDemo();

            _driver.FindElement(By.Name("BorrowedBTN")).Click();
            builder.MoveToElement(_driver.FindElement(By.Name("ProfileDropdown"))).Perform();
            DelayForDemo();

            _driver.FindElement(By.Name("SettingBTN")).Click();

            _driver.Close();
        }

        [TestMethod]
        public void ReadListpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395");

            Actions builder = new Actions(_driver);

            builder.MoveToElement(_driver.FindElement(By.Name("readBTN"))).Perform();

            DelayForDemo();
            
            _driver.FindElement(By.Name("ActionBTN")).Click();
            DelayForDemo();

            _driver.Close();
        }

        [TestMethod]
        public void AdminPanelpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login");

            //Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("Admin");
            DelayForDemo();

            //Password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("Admin");
            DelayForDemo();

            //remember me click
            _driver.FindElement(By.Name("RememberMe")).Click();

            //log in click
            _driver.FindElement(By.Name("LoginBTN")).Click();

            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();

            _driver.FindElement(By.Name("AdminPanelBTN")).Click();

            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();

            //create a new in the admin panel
            _driver.FindElement(By.Name("AdminPanelCreateNewBTN")).Click();

            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();

            //title
            IWebElement title = _driver.FindElement(By.Name("Title"));
            title.SendKeys("ASEBOOK");
            DelayForDemo();

            //description
            IWebElement description = _driver.FindElement(By.Name("Description"));
            description.SendKeys("Amazingbooks");
            DelayForDemo();

            //author
            IWebElement author = _driver.FindElement(By.Name("Author"));
            author.SendKeys("ASE");
            DelayForDemo();

            //coverURL
            IWebElement coverurl = _driver.FindElement(By.Name("CoverURL"));
            coverurl.SendKeys("123@ac.nz");
            DelayForDemo();

            //select in genre click
            _driver.FindElement(By.Name("Genre")).Click();

            //Young adult click
            _driver.FindElement(By.Name("YoungAdult")).Click();

            //create new click
            _driver.FindElement(By.Name("CreateBTN")).Click();

            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();
            DelayForDemo();

            //DELETE from the library
            _driver.FindElement(By.Name("ASEBOOK BTN")).Click();

            _driver.Close();
        }
        
        [TestMethod]
        public void Searchpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/");

            IWebElement author = _driver.FindElement(By.Name("Query"));
            author.SendKeys("ASE");
            DelayForDemo();

            Actions builder = new Actions(_driver);
            builder.KeyDown(Keys.Enter);

            _driver.Close();
        }
    }
   
        

     }

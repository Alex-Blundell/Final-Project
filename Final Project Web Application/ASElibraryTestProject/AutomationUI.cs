using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support;
using System;
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
            _driver = new ChromeDriver();
        }
        [TestMethod]
        public void Registerpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");
            Assert.AreEqual("Register - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void Registerwithuserdetail()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Login/SignUp");

            //Username
            IWebElement username = _driver.FindElement(By.Name("Username"));
            username.SendKeys("Eva");
            DelayForDemo();

            //Password
            IWebElement password = _driver.FindElement(By.Name("Password"));
            password.SendKeys("123");
            DelayForDemo();

            //log in click
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
        [TestMethod]
        public void Loginwithuserdetail()
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

            _driver.Close();

        }
        private static void DelayForDemo()
        {
            Thread.Sleep(1000);

        }
        [TestMethod]
        public void homepage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/");
            Assert.AreEqual("Home Page - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void ActionandAdvantageinReadpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Read?Genre=ActionAdventure");
            Assert.AreEqual("Index - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void ClassicinReadpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Read?Genre=Classic");
            Assert.AreEqual("Index - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void Forumspage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Forum");
            Assert.AreEqual("Forums - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void TopicinForumspage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Forum?Name=Introductions");
            Assert.AreEqual("Forums - Final Project Web Application", _driver.Title);

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
        public void Profilepage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Profile?Username=Admin");

            Assert.AreEqual("- Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void ReadListpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Profile/ReadList");
            Assert.AreEqual("Index - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void Settingspage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Profile/Settings");
            Assert.AreEqual("- Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void AdminPanelpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/AdminPanel");
            Assert.AreEqual("Index - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
        [TestMethod]
        public void CreateNewInAdminPanelpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/AdminPanel/AddBook");
            Assert.AreEqual("AddBook - Final Project Web Application", _driver.Title);

            _driver.Close();
        }

        [TestMethod]
        public void Searchpage()
        {
            _driver.Navigate().GoToUrl("https://localhost:44395/Home/Search");
            Assert.AreEqual("Search Results - Final Project Web Application", _driver.Title);

            _driver.Close();
        }
    }
}

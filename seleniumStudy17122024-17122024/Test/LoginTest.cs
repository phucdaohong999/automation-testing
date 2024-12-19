using System;
using FluentAssert;
using Microsoft.VisualStudio.TestTools.UnitTesting.Logging;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using static System.Net.Mime.MediaTypeNames;

namespace seleniumStudy17122024_17122024.Test
{
    [TestClass]
    public class LoginTest
    {
        private IWebDriver driver;
        [TestInitialize]
        public void SetupAndOpenDriver()
        {
            //Init driver for google chrome
            driver = new ChromeDriver();
        }
        [TestMethod]
        public void Verify_Positive_LoginTest()
        {
            //            Test case 1:
            //                Positive LogIn test
            //Open page
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            //Type username student into Username field
            driver.FindElement(By.XPath("//input[@id = 'username']")).SendKeys("student");

            //Type password Password123 into Password field
            driver.FindElement(By.XPath("//input[@id = 'password']")).SendKeys("Password123");

            //Push Submit button
            driver.FindElement(By.XPath("//button[@id = 'submit']")).Click();

            //Verify new page URL contains practicetestautomation.com / logged -in-successfully /
            driver.Url.ShouldContain("practicetestautomation.com/logged-in-successfully/");

            //Verify new page contains expected text('Congratulations' or 'successfully logged in')
            string loggedTitlePage = driver.FindElement(By.XPath("//h1[@class = 'post-title']")).Text;
            loggedTitlePage.ShouldBeEqualTo("Logged In Successfully");

            //Verify button Log out is displayed on the new page
            bool isLogoutButtonDisplay = driver.FindElement(By.XPath("//a[text() = 'Log out']")).Displayed;
            isLogoutButtonDisplay.ShouldBeTrue();
        }

        [TestCleanup]
        public void BrowserCleanup()
        {
            driver.Quit();
        }
    }
}

 
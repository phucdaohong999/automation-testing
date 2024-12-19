using System;
using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace seleniumStudy17122024_17122024.Test
{
    [TestClass]
    public class NegativeUsernameTest
    {
        private IWebDriver driver;

        [TestInitialize]
        public void SetupAndOpenBrowser()
        {
            driver = new ChromeDriver();
        }

        //        Test case 2: Negative username test
        [TestMethod]
        public void Verify_Negative_Username_Test()
        {
            //        Open page
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            //        Type username incorrectUser into Username field
            driver.FindElement(By.XPath("//input[@id = 'username']")).SendKeys("incorrectUser");

            //        Type password Password123 into Password field
            driver.FindElement(By.XPath("//input[@id = 'password']")).SendKeys("Password123");

            ////        Push Submit button
            driver.FindElement(By.XPath("//button[@id = 'submit']")).Click();

            //WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            //IWebElement element = wait.Until(driver => driver.FindElement(By.XPath("div[@id = 'error']")));

            ////Verify error message is displayed
            bool isErrorMessageDisplay = driver.FindElement(By.XPath("//div[@id = 'error']")).Displayed;
            isErrorMessageDisplay.ShouldBeTrue();

            ////Verify error message text is Your username is invalid!
            string errorMessage = driver.FindElement(By.XPath("//div[@id = 'error']")).Text;
            errorMessage.ShouldBeEqualTo("Your username is invalid!");
        }


        [TestCleanup]
        public void BrowserCleanup()
        {
            driver.Quit();
        }
    }
}


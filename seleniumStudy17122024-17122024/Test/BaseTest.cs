using System;
using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using seleniumStudy17122024_17122024.Pages;

namespace seleniumStudy17122024_17122024.Test
{
    [TestClass]
    public class BaseTest
    {
        protected IWebDriver driver;
        protected LoginPage loginPage;

        [TestInitialize]
        public void SetupAndOpenBrowser()
        {
            //Init driver for google chrome
            driver = new ChromeDriver();

            //Set implicit wait
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            driver.Manage().Window.Maximize();
        }

        [TestCleanup]
        public void BrowserCleanup()
        {
            driver.Quit();
        }
    }
}


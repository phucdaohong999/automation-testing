using System;
using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumStudy17122024_17122024.Test
{
	[TestClass]
	public class NegativePasswordTest
	{
		private IWebDriver driver;
		[TestInitialize]
		public void SetupAndOpenBrowser()
		{
			driver = new ChromeDriver();
		}

        [TestMethod]
        //        Test case 3: Negative password test
        //Open page
        //Type username student into Username field
        //Type password incorrectPassword into Password field
        //Push Submit button
        //Verify error message is displayed
        //Verify error message text is Your password is invalid!
        public void Verify_Negative_Password()
        {
            driver.Navigate().GoToUrl("https://practicetestautomation.com/practice-test-login/");

            driver.FindElement(By.XPath("//input[@id = 'username']")).SendKeys("student");

            driver.FindElement(By.XPath("//input[@id = 'password']")).SendKeys("incorrectPassword");

            driver.FindElement(By.XPath("//button[@id = 'submit']")).Click();

            bool isErrorMessageDisplay = driver.FindElement(By.XPath("//div[@id = 'error']")).Displayed;
            isErrorMessageDisplay.ShouldBeTrue();

            string errorMessage = driver.FindElement(By.XPath("//div[@id = 'error']")).Text;
            errorMessage.ShouldBeEqualTo("Your password is invalid!");
        }

        [TestCleanup]
        public void TestCleanup()
        {
            driver.Quit();
        }
	}
}


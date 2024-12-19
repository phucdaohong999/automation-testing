using System;
using System.Collections;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace seleniumStudy17122024_17122024.SeleniumLearning1812202418122024
{
	[TestClass]
	public class TestRadioButton
	{
		private IWebDriver driver;
		[TestInitialize]
		public void OpenBrowser()
		{
			driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
            driver.Manage().Window.Maximize();
            driver.Url = "https://rahulshettyacademy.com/loginpagePractise/";
        }

		[TestMethod]
        [Obsolete]
        public void TestClickRadioButton()
		{
			//Get list of radio button
			IList<IWebElement> radioButtonList = driver.FindElements(By.XPath("//input[@type = 'radio']"));

			//Loop in list of radio button, if value = user, click this button
			foreach (IWebElement radioButton in radioButtonList)
			{
				string radioButtonValue = driver.FindElement(By.XPath("//input[@value = 'user']")).GetAttribute("value");

                if (radioButtonValue.Equals("user"))
				{
					radioButton.Click();
				}
			}
		}

		[TestCleanup]
		public void CleanUp()
		{
			driver.Quit();
		}
	}
}


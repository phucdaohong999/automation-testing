using System;
using OpenQA.Selenium;

namespace seleniumStudy17122024_17122024.Pages
{
    public class LoginPage : BasePage
    {
        public LoginPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Type username student into Username field
        private IWebElement inputUsername => driver.FindElement(By.XPath("//input[@name = 'username']"));

        //Type password Password123 into Password field
        private IWebElement inputPassword => driver.FindElement(By.XPath("//input[@name = 'password']"));

        //Push Submit button
        private IWebElement buttonLogin => driver.FindElement(By.XPath("//button[contains(., 'Login')]"));

        //Method interact
        public void EnterUsername(string username)
        {
            inputUsername.SendKeys(username);
        }

        public void EnterPassword(string password)
        {
            inputPassword.SendKeys(password);
        }

        public void ClickSubmitButton()
        {
            buttonLogin.Click();
        }

        public void EnterUsernameAndPassword(string username, string password)
        {
            EnterUsername(username);
            EnterPassword(password);
        }
    }
}


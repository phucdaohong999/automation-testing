using System;
using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using seleniumStudy17122024_17122024.Pages;

namespace seleniumStudy17122024_17122024.Test
{
    [TestClass]
    public class LoginTestORM : BaseTest
    {
        private LoginPage loginPage;
        private DashboardPage dashboardPage;

        //public LoginTestORM(LoginPage loginPage, DashboardPage dashboardPage)
        //{
        //    this.loginPage = loginPage;
        //    this.dashboardPage = dashboardPage;
        //}

        [TestMethod]
        public void LoginTestWithWait()
        {
            //Init pages
            loginPage = new LoginPage(driver);
            dashboardPage = new DashboardPage(driver);

            driver.Navigate().GoToUrl("https://opensource-demo.orangehrmlive.com/web/index.php/auth/login");

            //Type username student into Username field
            //Type password Password123 into Password field
            //driver.FindElement(By.XPath("//input[@name = 'username']")).SendKeys("Admin");
            //driver.FindElement(By.XPath("//input[@name = 'password']")).SendKeys("admin123");
            loginPage.EnterUsernameAndPassword("Admin", "admin123");

            //Push Submit button
            //driver.FindElement(By.XPath("//button[contains(., 'Login')]")).Click();
            loginPage.ClickSubmitButton();

            driver.Url.ShouldContain("/dashboard");

            //Verify chart exists
            //dashboardPage.VerifyChartTimeExist();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8));
            wait.Until(d => dashboardPage.VerifyChartTimeExist());
        }
    }
}


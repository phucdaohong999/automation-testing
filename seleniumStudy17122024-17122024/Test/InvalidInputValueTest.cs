using System;
using System.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using seleniumStudy17122024_17122024.Pages;

namespace seleniumStudy17122024_17122024.Test
{
    [TestClass]
    public class InvalidInputValueTest : BaseTest
    {
        private LoginPage loginPage;

        [TestMethod]
        public void ConfirmLogin()
        {
            loginPage = new LoginPage(driver);

            loginPage.GoToLogin();

            //Type username student into Username field
            //Type password Password123 into Password field
            loginPage.EnterUsernameAndPassword("Admin", "admin123");

            //Push Submit button
            loginPage.ClickSubmitButton();

            //Navigate to Add Entitlements page
            driver.FindElement(By.XPath("//a[@class='oxd-main-menu-item']//span[text() = 'Leave']")).Click();
            driver.FindElement(By.XPath("//li//span[contains(text(),'Entitlements')]")).Click();
            driver.FindElement(By.XPath("//a[text()='Add Entitlements']")).Click();

            //Input and select invalid values
            driver.FindElement(By.XPath("//input[contains(@placeholder,'Type for hints')]")).SendKeys("bard");
            driver.FindElement(By.XPath("//div/div[text() = '2024-01-01 - 2024-31-12']")).Click();
            driver.FindElement(By.XPath("//div[@role ='listbox']//div[text() ='-- Select --']")).Click();
            driver.FindElement(By.XPath("//label[text()='Entitlement']/../following-sibling::div//input")).SendKeys("aa");

            //Verify error messages are showing
            string employeeNameError = driver.FindElement(By.XPath("//label[text() ='Employee Name']//..//following-sibling::div//following-sibling::span")).Text;
            Assert.AreEqual(employeeNameError, "Invalid");
            string leavePeriodError = driver.FindElement(By.XPath("//label[text() ='Leave Period']//..//following-sibling::div//following-sibling::span")).Text;
            Assert.AreEqual(leavePeriodError, "Required");
            string entitlementError = driver.FindElement(By.XPath("//label[text() ='Entitlement']//..//following-sibling::div//following-sibling::span")).Text;
            Assert.AreEqual(entitlementError, "Should be a number with upto 2 decimal places");

        }
    }
}

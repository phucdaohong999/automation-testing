using System;
using FluentAssert;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace seleniumStudy17122024_17122024.Pages
{
    public class DashboardPage : BasePage
    {
        public DashboardPage(IWebDriver _driver) : base(_driver)
        {
        }

        //Web Element
        private IWebElement chartTimeAtWork => driver.FindElement(By.XPath("//div[@class='emp-attendance-chart']"));


        public bool VerifyChartTimeExist()
        {
            return chartTimeAtWork.Displayed;
        }
    }
}


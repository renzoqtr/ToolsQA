using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;


namespace ToolsQA.Pages
{
    public class BookStorePage
    {
        private readonly string URL = "https://demoqa.com/profile";
        private IWebDriver Driver;
        private WebDriverWait DoWait;
        private By SearchField = By.Id("searchBox");
        private By Results = By.CssSelector("div.rt-td > img");

        public BookStorePage(IWebDriver Driver) { 
            this.Driver = Driver;
            DoWait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(10));
        }

        public bool IsSeachDisplayed() {
            return DoWait.Until(ExpectedConditions.ElementIsVisible(SearchField)).Displayed;
        }

        public IReadOnlyCollection<IWebElement> GetResults() {
            return Driver.FindElements(Results);

        }
    }
}

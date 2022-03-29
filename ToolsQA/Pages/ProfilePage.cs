using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using OpenQA.Selenium.Interactions;

namespace ToolsQA.Pages
{
    public class ProfilePage
    {

        private readonly string URL = "https://demoqa.com/profile";
        private IWebDriver Driver;
        private WebDriverWait DoWait;
        private By GoToStoreButton = By.Id("gotoStore");
        private By UserNameLabel = By.Id("userName-value");
        private By GoogleAds = By.Id("close-fixedban");

        private const int DefaulTimeOut = 10;


        public ProfilePage(IWebDriver Driver) {
            this.Driver = Driver;
            DoWait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(DefaulTimeOut));
        }

        public string GetCurrentUrl() {
            return Driver.Url;
        }

        public void WaitForUserName() {
            DoWait.Until(ExpectedConditions.ElementIsVisible(UserNameLabel));
        }

        public void ClickOnStore() {
            DoWait.Until(ExpectedConditions.ElementToBeClickable(GoToStoreButton)).Click();
        }

        public void CloseAd() { 
            DoWait.Until(ExpectedConditions.ElementToBeClickable(GoogleAds)).Click();
        }

        public void ScrollToBottom()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor) Driver;
            js.ExecuteScript("window.scrollTo(0, document.body.scrollHeight);");
        }


    }
}

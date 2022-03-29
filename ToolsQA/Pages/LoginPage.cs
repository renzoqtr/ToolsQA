using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace ToolsQA.Pages
{
    public class LoginPage
    {
        private readonly string URL = "https://demoqa.com/login";
        private IWebDriver Driver;
        private WebDriverWait DoWait;
        private By UsernameField = By.Id("userName");
        private By PasswordField = By.Id("password");
        private By LoginButton = By.Id("login");
        private const int DefaulTimeOut = 10;

        public LoginPage(IWebDriver Driver) {
            this.Driver = Driver;
            DoWait = new WebDriverWait(this.Driver, TimeSpan.FromSeconds(DefaulTimeOut));
        }

        public void OpenLogin() {
            Driver.Navigate().GoToUrl(URL);
        }

        public void ClickOnLogin() {
            DoWait.Until(ExpectedConditions.ElementToBeClickable(LoginButton)).Click();
        }

        public void WriteOnUsername(string text) {
            var Element = DoWait.Until(ExpectedConditions.ElementToBeClickable(UsernameField));
            Element.Click();
            Element.Clear();
            Element.SendKeys(text);
        }
        public void WriteOnPassword(string text) {
            var Element = DoWait.Until(ExpectedConditions.ElementToBeClickable(PasswordField));
            Element.Click();
            Element.Clear();
            Element.SendKeys(text);
        }

    }
}

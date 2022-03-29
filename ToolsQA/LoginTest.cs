using NUnit.Framework;
using System.IO;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using ToolsQA.Pages;

namespace ToolsQA
{
    public class Tests
    {
        private IWebDriver Driver;

        [SetUp]
        public void Setup()
        {
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;
            Driver = new ChromeDriver(path + @"\drivers\");
            Driver.Manage().Window.Maximize();
        }
 
        [Test]
        public void GoToStore()
        {
            LoginPage Login = new LoginPage(Driver);
            Login.OpenLogin();
            Login.WriteOnUsername("DaUser");
            Login.WriteOnPassword("DaPass1!");
            Login.ClickOnLogin();
            ProfilePage Profile = new ProfilePage(Driver);
            Profile.WaitForUserName();
            Assert.True(Profile.GetCurrentUrl().Equals("https://demoqa.com/profile"));
            Profile.CloseAd();
            Profile.ScrollToBottom();
            Profile.ClickOnStore();
            BookStorePage BookStore = new BookStorePage(Driver);
            Assert.True(BookStore.IsSeachDisplayed());
            Assert.True(BookStore.GetResults().Count > 1);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }

    }
}
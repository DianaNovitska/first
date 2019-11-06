using System;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;
using OpenQA.Selenium.Support.UI;
using System.Threading;

namespace UnitTestProject1
{
    class HomePage
    {
        private IWebDriver driver;
        private string url = @"https://www.google.com/";
        

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            this.driver.Manage().Window.Maximize();
            InitElements(driver, this);
            }
        [FindsBy(How = How.XPath, Using = "//a[@id='gb_70']")]
        public IWebElement loginButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@ class= 'gb_Kf']")]
        public IWebElement menuButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//li[@ id= 'ogbkddg:5']")]
        public IWebElement gmailButton { get; set; }
            

            public void Navigate()
        {
            driver.Navigate().GoToUrl(url);
        }

        public LoginPage goToLoginPage()
        {
            Navigate();
            Thread.Sleep(3000);
            loginButton.Click();
            return new LoginPage(driver);
        }

        public GmailPage goToGmailPage()
        {
            menuButton.Click();
            gmailButton.Click();
            return new GmailPage(driver);
        }
    }
}

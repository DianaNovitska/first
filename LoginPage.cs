using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;
using OpenQA.Selenium.Support.UI;

namespace UnitTestProject1
{
    class LoginPage
    {
        private IWebDriver driver;
        public LoginPage(IWebDriver driver)
        {
            this.driver = driver;
            InitElements(driver, this);
        }

        [FindsBy(How = How.XPath, Using = "//input[@id='identifierId']")]
        public IWebElement login{ get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@ class = 'CwaK9']")]
        public IWebElement next { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@ type = 'password']")]
        public IWebElement password { get; set; }

         public HomePage Authorization(string login_text, string password_text)
        {
            login.SendKeys(login_text);
            next.Click();
            Thread.Sleep(3000);
            password.SendKeys(password_text);
            next.Click();
            return new HomePage(driver);
        }   
    }
}

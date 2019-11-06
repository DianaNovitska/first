using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Threading;

using System.Threading.Tasks;

namespace UnitTestProject1
{
    [TestClass]
    public class UnitTestTask
    {
        
        public static IWebDriver driver = new ChromeDriver();
        HomePage home = new HomePage(driver);
        LoginPage login = new LoginPage(driver);
        GmailPage gmail = new GmailPage(driver);

        public void Authorized(string login_text, string password)
        {
            home.goToLoginPage();
            login.Authorization(login_text, password);
            Thread.Sleep(3000);
            home.goToGmailPage();
        }
        [TestInitialize]
        public void Initialize()
        {
            Authorized("testtaskdiana@gmail.com", "1a2b3c4d5e6Fj7");
        }
        
        [TestMethod]
        public void DraftIsCreated()
        {                    
            gmail.CreateDraft("d@gmail.com", "testtask", "Dear");
            Thread.Sleep(8000);
            Assert.AreEqual("testtaskDear", gmail.DraftsName());
        }

        [TestMethod]
        public void DraftIsUpdated()
        {
            Thread.Sleep(8000);
            gmail.UpdateDraft("di@gmail.com", "test", "Hear");
            Thread.Sleep(8000);
            Assert.AreEqual("testHear", gmail.DraftsName());
            if (gmail.DraftsName().Equals("testHear"))
            {
                gmail.Delete.Click();
            }
            else
            {
                Console.WriteLine("The draft wasn't created");
            }
            
        }
        [TestCleanup]
        public void Cleanup()
        {
            driver.Close();
            driver.Quit();
        }
    }
    
}

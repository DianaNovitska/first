using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using static OpenQA.Selenium.Support.PageObjects.PageFactory;
using System.Threading;

namespace UnitTestProject1
{
    class GmailPage
    {
        public IWebDriver driver;

        public GmailPage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(8);
            this.driver.Manage().Window.Maximize();
            InitElements(driver, this);
        }

         [FindsBy(How = How.XPath, Using = "(//a[@class='J-Ke n0'])[5]")]
        public IWebElement DraftFolder { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@gh='cm']")]
        public IWebElement Compose { get; set; }
        [FindsBy(How = How.XPath, Using = "//textarea[@aria-label ='To']")]
        public IWebElement Recipients { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public IWebElement Subject { get; set; }      
        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Message Body']")]
        public IWebElement Text { get; set; }
        [FindsBy(How = How.XPath, Using = "//img[@aria-label='Save & close'] ")]
        public IWebElement Close { get; set; }

        [FindsBy(How = How.XPath, Using = "(//tr[@role='row'])[2]")]
        public IWebElement DraftToUpdate { get; set; }

        [FindsBy(How = How.XPath, Using = "(//span[@class='bog'])[2]")]
        public IWebElement DraftName { get; set; }
        [FindsBy(How = How.XPath, Using = "(//span[@class='y2'])[2]")]
        public IWebElement DraftName2 { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[contains(@aria-label,'Discard draft')]")]
        public IWebElement Delete { get; set; }

        public void CreateDraft(string recipient, string subj, string message)
        {
            DraftFolder.Click();
            Compose.Click();
            Recipients.SendKeys(recipient);
            Subject.SendKeys(subj);
            Text.SendKeys(message);
            Close.Click();

        }
        public string DraftsName()
        {
            return DraftName.Text+ DraftName2.Text.ToString().Remove(0, 5);
        }
        public void UpdateDraft(string recipient, string subj, string message)
        {
            DraftFolder.Click();
            DraftToUpdate.Click();
            Text.Clear();
            Text.SendKeys(message);
            Subject.Clear();
            Subject.SendKeys(subj);           
        }
    }
}

using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject
{
    public class Base
    {
        protected IWebDriver driver;
        protected WebDriverWait wait;
        protected Actions actions;

        [SetUp]

        public void setUp()
        {
            string browserName = ConfigurationManager.AppSettings["ChromeBrowser"];
            driver = BrowserFactory.InitWebBrowser(browserName);
            driver.Manage().Window.Maximize();
            driver.Url = "https://automationexercise.com";
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            actions = new Actions(driver);
        }

        [TearDown]

        public void close()
        {
            driver.Dispose();
            driver.Quit();
        }

        private IWebElement Find(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(locator));
            return driver.FindElement(locator);
        }

        public void WriteOnElement(By locator, string textToWrite)
        {
            Find(locator).SendKeys(textToWrite);
        }

        public void ClearElement(By locator)
        {
            Find(locator).Clear();
        }

        public void ClickOnElement(By locator)
        {
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(locator));
            actions.MoveToElement(Find(locator)).Perform();
            Find(locator).Click();
        }

        public void Select(By locator, string textOption)
        {
            new SelectElement(Find(locator)).SelectByText(textOption);
        }

        public void VerifyElementIsVisibleByLocator(By locator)
        {
            Assert.That(Find(locator).Displayed, Is.True);
        }

        public void VerifyElementIsVisible(IWebElement element)
        {
            Assert.That(element.Displayed, Is.True);
        }

        public void ValidateMsg(By locator, string msg)
        {
            Assert.That(Find(locator).Text, Does.Contain(msg));
        }

        public void ValidateElementTextContent(IWebElement element, string textContent)
        {
            Assert.That(element.Text.ToLower, Does.Contain(textContent));
        }

        public void ValidateUrl(string url)
        {
            Assert.That(driver.Url, Does.Contain(url));
        }

        public void ScrollToElementByLocator(By locator)
        {
            actions.ScrollToElement(Find(locator)).Perform();
        }

        public void HoverOverElement(IWebElement element)
        {
            actions.MoveToElement(element).Perform();
        }

    }
}

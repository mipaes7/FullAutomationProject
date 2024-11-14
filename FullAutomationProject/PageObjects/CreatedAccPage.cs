using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class CreatedAccPage : Base
    {
        public readonly By createdAccBanner;
        public readonly By continueBtn;

        public CreatedAccPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.createdAccBanner = By.CssSelector("section h2");
            this.continueBtn = By.CssSelector("section a");
        }

        public void VerifyCreatedAccountBannerIsVisible(string msg = "ACCOUNT CREATED!")
        {
            VerifyElementIsVisibleByLocator(createdAccBanner);
            TestContext.Progress.WriteLine(driver.FindElement(createdAccBanner).Text);
            ValidateMsg(createdAccBanner, msg);
        }

        public void ClickOnContinueBtn()
        {
            ClickOnElement(continueBtn);
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class DeletedAccPage : Base
    {
        public readonly By deletedAccMsg;

        public DeletedAccPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.deletedAccMsg = By.CssSelector("section h2");
        }

        public void VerifyDeletedAccMsgIsVisible(string msg = "ACCOUNT DELETED!")
        {
            ValidateMsg(deletedAccMsg, msg);
            VerifyElementIsVisibleByLocator(deletedAccMsg);
        }
    }
}

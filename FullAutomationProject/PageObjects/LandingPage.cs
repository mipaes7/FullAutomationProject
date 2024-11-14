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
    internal class LandingPage : Base
    {
        public readonly By consentFrameLocator;
        public readonly By consentBtn;
        public readonly By authBtn;
        public readonly By loggedAsUserMsg;
        public readonly By deleteAccBtn;
        public readonly By logoutBtn;
        public readonly By contactUsBtn;
        public readonly By testCasesBtn;
        public readonly By productsBtn;
        public readonly By footer;
        public readonly By subscriptionTitle;
        public readonly By subscriptionEmailInput;
        public readonly By subscriptionEmailSubmitBtn;
        public readonly By subscriptionAlert;
        public readonly By goToCartBtn;

        public LandingPage(IWebDriver driver, WebDriverWait wait, Actions actions) 
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.consentFrameLocator = By.CssSelector("div[class='fc-consent-root']");
            this.consentBtn = By.CssSelector("button.fc-button.fc-cta-consent");
            this.authBtn = By.CssSelector("a[href='/login']");
            this.loggedAsUserMsg = By.CssSelector("a i[class='fa fa-user']");
            this.deleteAccBtn = By.CssSelector("a[href='/delete_account']");
            this.logoutBtn = By.CssSelector("a[href='/logout']");
            this.contactUsBtn = By.CssSelector("a[href='/contact_us']");
            this.testCasesBtn = By.CssSelector("a[href='/test_cases']");
            this.productsBtn = By.CssSelector("a[href='/products']");
            this.goToCartBtn = By.CssSelector("a[href='/view_cart']");
            this.footer = By.Id("footer");
            this.subscriptionTitle = By.CssSelector("footer h2");
            this.subscriptionEmailInput = By.CssSelector("footer input[type='email']");
            this.subscriptionEmailSubmitBtn = By.CssSelector("footer button");
            this.subscriptionAlert = By.Id("success-subscribe");
        }

        public void ClickOnConsentBtn()
        {
            ClickOnElement(consentBtn);
        }

        public void VerifyLandingPageUrl()
        {
            string url = driver.Url;
            Assert.That(url, Is.EqualTo("https://automationexercise.com/"));
        }

        public void ClickOnAuthBtn()
        {
            ClickOnElement(authBtn);
        }

        public void VerifyLoggedAsUserMsgIsVisible()
        {
            VerifyElementIsVisibleByLocator(loggedAsUserMsg);
        }

        public void ClickOnDeleteAccBtn()
        {   
            VerifyElementIsVisibleByLocator(deleteAccBtn);
            ClickOnElement(deleteAccBtn);
        }

        public void ClickOnLogoutBtn()
        {
            ClickOnElement(logoutBtn);
        }

        public void ClickOnContactUsBtn()
        {
            ClickOnElement(contactUsBtn);
        }

        public void ClickOnTestCasesBtn()
        {
            ClickOnElement(testCasesBtn);
        }

        public void ClickOnProductsBtn()
        {
            ClickOnElement(productsBtn);
        }

        public void ScrollToFooter()
        {
            ScrollToElementByLocator(footer);
        }

        public void VerifySubscriptionTitleIsVisible(string title)
        {
            VerifyElementIsVisibleByLocator(subscriptionTitle);
            ValidateMsg(subscriptionTitle, title);
        }

        public void SubmitSubscriptionEmail(string email)
        {
            WriteOnElement(subscriptionEmailInput, email);
            ClickOnElement(subscriptionEmailSubmitBtn);
        }

        public void VerifySubscriptionAlertIsVisible(string alertText)
        {
            VerifyElementIsVisibleByLocator(subscriptionAlert);
            ValidateMsg(subscriptionAlert, alertText);
        }

        public void ClickOnCartBtn()
        {
            ClickOnElement(goToCartBtn);
        }
    }
}

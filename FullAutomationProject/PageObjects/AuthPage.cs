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
    internal class AuthPage : Base
    {

        public readonly By signUpBanner;
        public readonly By loginBanner;
        public readonly By userNameSignUpInput;
        public readonly By emailSignUpInput;
        public readonly By signUpBtn;
        public readonly By emailLoginInput;
        public readonly By passwordInput;
        public readonly By loginBtn;
        public readonly By wrongLoginMsg;
        public readonly By wrongSignUpMsg;

        public AuthPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.signUpBanner = By.CssSelector("div[class='signup-form'] h2");
            this.loginBanner = By.CssSelector("div[class='login-form'] h2");
            this.userNameSignUpInput = By.CssSelector("div[class='signup-form'] form input[type='text']");
            this.emailSignUpInput = By.CssSelector("div[class='signup-form'] form input[type='email']");
            this.signUpBtn = By.CssSelector("div[class='signup-form'] form button[type='submit']");
            this.emailLoginInput = By.CssSelector("div[class='login-form'] form input[type='email']");
            this.passwordInput = By.CssSelector("div[class='login-form'] form input[type='password']");
            this.loginBtn = By.CssSelector("div[class='login-form'] form button");
            this.wrongLoginMsg = By.CssSelector("div[class='login-form'] p");
            this.wrongSignUpMsg = By.CssSelector("div[class='signup-form'] p");
        }

        public void VerifySignUpBannerIsVisible()
        {
            VerifyElementIsVisibleByLocator(signUpBanner);
        }

        public void VerifyLoginBannerIsVisible()
        {
            VerifyElementIsVisibleByLocator(loginBanner);
        }

        public void SignUpUser(string userName, string email)
        {
            WriteOnElement(userNameSignUpInput, userName);
            WriteOnElement(emailSignUpInput, email);
        }

        public void ClickOnSignUpBtn()
        {
            ClickOnElement(signUpBtn);
        }

        public void LoginUser(string userEmail, string password)
        {
            WriteOnElement(emailLoginInput, userEmail);
            WriteOnElement(passwordInput, password);
            ClickOnElement(loginBtn);
        }

        public void VerifyWrongLoginMsgIsVisible(string msg = "Your email or password is incorrect")
        {
            VerifyElementIsVisibleByLocator(wrongLoginMsg);
            ValidateMsg(wrongLoginMsg, msg);
        }

        public void VerifyWrongSignUpMsgIsVisible(string msg = "Email Address already exist!")
        {
            VerifyElementIsVisibleByLocator(wrongSignUpMsg);
            ValidateMsg(wrongSignUpMsg, msg);
        }

        public void ValidateAuthPageUrl(string url)
        {
            ValidateUrl(url);
        }

    }
}

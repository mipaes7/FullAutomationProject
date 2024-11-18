using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase3LoginUserWithIncorrectEmailAndPasswordTest : Base
    {
        [TestCase(TestName = "TestCase3LoginUserWithIncorrectEmailAndPassword")]
        public void TestCase3LoginUserWithIncorrectEmailAndPassword()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Verify that home page is visible successfully

            //Click on 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Verify 'Login to your account' is visible
            authPage.VerifyLoginBannerIsVisible();

            //Enter incorrect email address and password
            //Click 'login' button
            authPage.LoginUser(ConfigurationManager.AppSettings["UserEmail"], "wrongpswrd");

            //Verify error 'Your email or password is incorrect!' is visible
            authPage.VerifyWrongLoginMsgIsVisible();
        }
    }
}

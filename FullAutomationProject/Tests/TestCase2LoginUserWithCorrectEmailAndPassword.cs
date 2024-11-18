using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    class TestCase2LoginUserWithCorrectEmailAndPasswordTest : Base
    {
        [TestCase(TestName = "TestCase2LoginUserWithCorrectEmailAndPassword")]
        public void TestCase2LoginUserWithCorrectEmailAndPassword()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            DeletedAccPage deletedAccPage = new DeletedAccPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Verify that home page is visible successfully

            //Click on 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Verify 'Login to your account' is visible
            authPage.VerifyLoginBannerIsVisible();

            //Enter correct email address and password
            //Click 'login' button
            authPage.LoginUser(ConfigurationManager.AppSettings["UserEmail"], ConfigurationManager.AppSettings["Password"]);

            //Verify that 'Logged in as username' is visible
            landingPage.VerifyLoggedAsUserMsgIsVisible();

            //Click 'Delete Account' button
            landingPage.ClickOnDeleteAccBtn();

            //Verify that 'ACCOUNT DELETED!' is visible
            deletedAccPage.VerifyDeletedAccMsgIsVisible();
        }
    }
}

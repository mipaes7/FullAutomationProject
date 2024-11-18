using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase4LogoutUserTest : Base
    {
        [TestCase(TestName = "TestCase4LogoutUser")]
        public void TestCase4LogoutUser()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);

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

            //Click 'Logout' button
            landingPage.ClickOnLogoutBtn();

            //Verify that user is navigated to login page
            authPage.ValidateAuthPageUrl("login");
        }
    }
}

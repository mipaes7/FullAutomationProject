﻿using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase5RegisterUserWithExistingEmailTest : Base
    {

        [TestCase(TestName = "TestCase5RegisterUserWithExistingEmail")]
        public void TestCase5RegisterUserWithExistingEmail()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Verify that home page is visible successfully

            //Click on 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Verify 'New User Signup!' is visible
            authPage.VerifySignUpBannerIsVisible();

            //Enter name and already registered email address
            authPage.SignUpUser("name", ConfigurationManager.AppSettings["UserEmail"]);

            //Click 'Signup' button
            authPage.ClickOnSignUpBtn();

            //Verify error 'Email Address already exist!' is visible
            authPage.VerifyWrongSignUpMsgIsVisible();
        }

    }
}

using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase10VerifySubscriptionInHomePageTest : Base
    {

        [TestCase(TestName = "TestCase10VerifySubscriptionInHomePage")]

        public void TestCase10VerifySubscriptionInHomePage()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Scroll down to footer
            landingPage.ScrollToFooter();

            //Verify text 'SUBSCRIPTION'
            landingPage.VerifySubscriptionTitleIsVisible("SUBSCRIPTION");

            //Enter email address in input and click arrow button
            landingPage.SubmitSubscriptionEmail("email@email.com");

            //Verify success message 'You have been successfully subscribed!' is visible
            landingPage.VerifySubscriptionAlertIsVisible("You have been successfully subscribed");
        }

    }
}

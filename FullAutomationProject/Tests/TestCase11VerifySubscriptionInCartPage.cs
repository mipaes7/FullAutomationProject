using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase11VerifySubscriptionInCartPageTest : Base
    {

        [TestCase(TestName = "TestCase11VerifySubscriptionInCartPage")]

        public void TestCase11VerifySubscriptionInCartPage()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click 'Cart' button
            landingPage.ClickOnCartBtn();

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

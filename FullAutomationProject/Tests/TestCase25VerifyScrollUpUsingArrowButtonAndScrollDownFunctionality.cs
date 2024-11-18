using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase25VerifyScrollUpUsingArrowButtonAndScrollDownFunctionalityTest : Base
    {

        [TestCase (TestName = "TestCase25VerifyScrollUpUsingArrowButtonAndScrollDownFunctionality")]

        public void TestCase25VerifyScrollUpUsingArrowButtonAndScrollDownFunctionality()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Scroll down page to bottom
            ScrollToBottom();

            //Verify 'SUBSCRIPTION' is visible
            landingPage.VerifySubscriptionTitleIsVisible("SUBSCRIPTION");

            //Click on arrow at bottom right side to move upward
            ClickOnElement(landingPage.goUpArrowBtn);

            //Verify that page is scrolled up and 'Full-Fledged practice website for Automation Engineers' text is visible on screen
            VerifyElementIsVisibleByLocator(landingPage.carouselSubtitle);
        }

    }
}

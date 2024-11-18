using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase26VerifyScrollUpWithoutArrowButtonAndScrollDownFunctionalityTest : Base
    {

        [TestCase (TestName = "TestCase26VerifyScrollUpWithoutArrowButtonAndScrollDownFunctionality")]

        public void TestCase26VerifyScrollUpWithoutArrowButtonAndScrollDownFunctionality()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Scroll down page to bottom
            ScrollToBottom();

            //Verify 'SUBSCRIPTION' is visible
            landingPage.VerifySubscriptionTitleIsVisible("SUBSCRIPTION");

            //Scroll up page to top
            ScrollToTop();

            //Verify that page is scrolled up and 'Full-Fledged practice website for Automation Engineers' text is visible on screen
            VerifyElementIsVisibleByLocator(landingPage.carouselSubtitle);
        }

    }
}

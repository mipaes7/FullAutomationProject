using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase7VerifyTestCasesPageTest : Base
    {

        [TestCase (TestName = "TestCase7VerifyTestCasesPage")]

        public void TestCase7VerifyTestCasesPage()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            TestCasesPage testCasesPage = new TestCasesPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Test Cases' button
            landingPage.ClickOnTestCasesBtn();

            //Verify user is navigated to test cases page successfully
            testCasesPage.VerifyTestCasesPageUrl();

        }

    }
}

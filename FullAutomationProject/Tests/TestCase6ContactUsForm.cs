using FullAutomationProject.Enums;
using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase6ContactUsFormTest : Base
    {

        [TestCase(TestName = "TestCase6ContactUsForm")]

        public async Task TestCase6ContactUsForm()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            ContactUsPage contactUsPage = new ContactUsPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Contact Us' button
            landingPage.ClickOnContactUsBtn();

            //Verify 'GET IN TOUCH' is visible
            contactUsPage.VerifyGetInTouchBannerIsVisible();

            //Enter name, email, subject and message
            contactUsPage.FillContactUsForm(ContactUsFormField.Name, "Jonas");
            contactUsPage.FillContactUsForm(ContactUsFormField.Email, "email@email.com");
            contactUsPage.FillContactUsForm(ContactUsFormField.Subject, "subject");
            contactUsPage.FillContactUsForm(ContactUsFormField.Message, "message");

            //Upload file
            contactUsPage.UploadFile();

            //Click 'Submit' button
            contactUsPage.ClickOnSubmitForm();

            //Click OK button
            contactUsPage.AcceptAlert();

            //Verify success message 'Success! Your details have been submitted successfully.' is visible
            contactUsPage.VerifySuccesfulSubmissionMsgIsVisible();

            //Click 'Home' button and verify that landed to home page successfully
            contactUsPage.ClickOnGoToHomePageBtn();
            landingPage.VerifyLandingPageUrl();

        }

    }
}

using FullAutomationProject.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class ContactUsPage : Base
    {
        public readonly By getInTouchBanner;
        public readonly By nameInput;
        public readonly By emailInput;
        public readonly By subjectInput;
        public readonly By msgInput;
        public readonly By uploadFileInput;
        public readonly By submitFormBtn;
        public readonly By succesfulSubmissionMsg;
        public readonly By goToHomePageBtn;

        public ContactUsPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.getInTouchBanner = By.CssSelector("div[class='contact-form'] h2");
            this.nameInput = By.CssSelector("form[id='contact-us-form'] input[name='name']");
            this.emailInput = By.CssSelector("form[id='contact-us-form'] input[name='email']");
            this.subjectInput = By.CssSelector("form[id='contact-us-form'] input[name='subject']");
            this.msgInput = By.CssSelector("form[id='contact-us-form'] textarea");
            this.uploadFileInput = By.CssSelector("input[type='file']");
            this.submitFormBtn = By.CssSelector("input[type='submit']");
            this.succesfulSubmissionMsg = By.XPath("//div[@class='contact-form'] //div[contains(@class, 'succes')]");
            this.goToHomePageBtn = By.CssSelector("div[id='form-section'] a[class='btn btn-success']");
        }

        public void VerifyGetInTouchBannerIsVisible()
        {
            VerifyElementIsVisibleByLocator(getInTouchBanner);
        }

        public By GetContactFormInput(ContactUsFormField field)
        {
            By inputField = null;

            switch(field)
            {
                case ContactUsFormField.Name:
                    inputField = nameInput;
                    break;
                case ContactUsFormField.Email:
                    inputField = emailInput;
                    break;
                case ContactUsFormField.Subject:
                    inputField = subjectInput;
                    break;
                case ContactUsFormField.Message:
                    inputField = msgInput;
                    break;
            }

            return inputField;
        }

        public void FillContactUsForm(ContactUsFormField field, string text)
        {
            By inputField = GetContactFormInput(field);

            WriteOnElement(inputField, text);
        }

        public void UploadFile(string path = @"C:\Users\MPardal\Desktop\Captura de pantalla 2024-11-08 102748.png")
        {
            WriteOnElement(uploadFileInput, path);
        }

        public void ClickOnSubmitForm()
        {
            ClickOnElement(submitFormBtn);
        }

        public void AcceptAlert()
        {
            IAlert alert = driver.SwitchTo().Alert();
            alert.Accept();
        }

        public void VerifySuccesfulSubmissionMsgIsVisible()
        {
            VerifyElementIsVisibleByLocator(succesfulSubmissionMsg);
        }

        public void ClickOnGoToHomePageBtn()
        {
            ClickOnElement(goToHomePageBtn);
        }
    }
}

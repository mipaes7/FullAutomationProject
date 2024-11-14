using FullAutomationProject.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class PaymentPage : Base
    {
        public readonly By nameOnCardInput;
        public readonly By cardNumberInput;
        public readonly By cardPinCodeInput;
        public readonly By cardExpirationMMInput;
        public readonly By cardExpirationYYYYInput;
        public readonly By payAndConfirmOrderBtn;
        public readonly By succesfulPaymentALert;

        public PaymentPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.nameOnCardInput = By.CssSelector("input[name='name_on_card']");
            this.cardNumberInput = By.CssSelector("input[name='card_number']");
            this.cardPinCodeInput = By.CssSelector("input[name='cvc']");
            this.cardExpirationMMInput = By.CssSelector("input[name='expiry_month']");
            this.cardExpirationYYYYInput = By.CssSelector("input[name='expiry_year']");
            this.payAndConfirmOrderBtn = By.CssSelector("button[id='submit']");
            this.succesfulPaymentALert = By.CssSelector("div[class='payment-information'] div[class='alert-success alert']");
        }

        public By GetCreditCardInput(CreditCardFields field)
        {
            By inputField = null;

            switch(field)
            {
                case CreditCardFields.NameOnCard:
                    inputField = nameOnCardInput;
                    break;
                case CreditCardFields.CardNumber:
                    inputField = cardNumberInput;
                    break;
                case CreditCardFields.CardPINCode:
                    inputField = cardPinCodeInput;
                    break;
                case CreditCardFields.CardExpirationDateMM:
                    inputField = cardExpirationMMInput;
                    break;
                case CreditCardFields.CardExpirationDateYYYY:
                    inputField = cardExpirationYYYYInput;
                    break;
            }

            return inputField;
        }

        public void FillCreditCardInfo(CreditCardFields input, string infoToFill)
        {
            By inputField = GetCreditCardInput(input);
            WriteOnElement(inputField, infoToFill);
        }

        public void ClickOnConfirmOrder()
        {
            ClickOnElement(payAndConfirmOrderBtn);
        }

        public void VerifySuccesfulPaymentAlert(string msg)
        {
            VerifyElementIsVisibleByLocator(succesfulPaymentALert);
            ValidateMsg(succesfulPaymentALert, msg);
        }

    }
}

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
    internal class ProductDetailsPage : Base
    {

        public readonly By productInfoDetails;
        public readonly By productQuantityInput;
        public readonly By addToCartBtn;
        public readonly By productReviewContainer;
        public readonly By productReviewNameInput;
        public readonly By productReviewEmailInput;
        public readonly By productReviewReviewInput;
        public readonly By submitReviewBtn;
        public readonly By reviewSuccessAlert;

        public ProductDetailsPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            //utilizo un selector que localiza todos los hijos de un elemento: //elemento /*
            //así puedo iterar el array y comprobar que los elementos sean visibles
            this.productInfoDetails = By.XPath("//div[@class='product-information'] /*");
            this.productQuantityInput = By.CssSelector("input[name='quantity']");
            this.addToCartBtn = By.CssSelector("div[class='product-information'] button");
            this.productReviewContainer = By.CssSelector("div[class='category-tab shop-details-tab']");
            this.productReviewNameInput = By.CssSelector("form[id='review-form'] input[id='name']");
            this.productReviewEmailInput = By.CssSelector("form[id='review-form'] input[id='email']");
            this.productReviewReviewInput = By.CssSelector("form[id='review-form'] textarea");
            this.submitReviewBtn = By.Id("button-review");
            this.reviewSuccessAlert = By.CssSelector("div[class='category-tab shop-details-tab'] div[class='alert-success alert']");
        }

        public void VerifyProductDetailsPageUrl()
        {
            string url = driver.Url;
            ValidateUrl(url);
        }

        public void VerifyProductDetailsInfoIsVisible()
        {
            IList<IWebElement> infoDetails = driver.FindElements(productInfoDetails);
            foreach (IWebElement infoDetailsItem in infoDetails)
            {
                VerifyElementIsVisible(infoDetailsItem);
            }
        }

        public void ChangeProductQuantity(int quantity)
        {
            ClearElement(productQuantityInput);
            WriteOnElement(productQuantityInput, quantity.ToString());
        }

        public void ClickOnAddToCart()
        {
            ClickOnElement(addToCartBtn);
        }

        public void VerifyReviewContainerIsVisible()
        {
            VerifyElementIsVisibleByLocator(productReviewContainer);
        }

        public By GetReviewInputField(ReviewFields field)
        {
            By inputField = null;

            switch(field)
            {
                case ReviewFields.Name:
                    inputField = productReviewNameInput;
                    break;
                case ReviewFields.EmailAddress:
                    inputField = productReviewEmailInput;
                    break;
                case ReviewFields.Review:
                    inputField = productReviewReviewInput;
                    break;
            }

            return inputField;
        }

        public void FillReviewForm(ReviewFields input, string text)
        {
            By field = GetReviewInputField(input);

            WriteOnElement(field, text);
        }

        public void ClickOnSubmitReview()
        {
            ClickOnElement(submitReviewBtn);
        }

        public void VerifyReviewSuccesAlertIsVisible()
        {
            VerifyElementIsVisibleByLocator(reviewSuccessAlert);
        }
    }
}

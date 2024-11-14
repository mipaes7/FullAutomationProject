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
    }
}

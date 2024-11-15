using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.DOM;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class CartPage : Base
    {

        public readonly By cartProdcutsList;
        public readonly By productQuantity;
        public readonly By productPrice;
        public readonly By productTotal;
        public readonly By proceedToCheckoutBtn;
        public readonly By productDescription;
        public readonly By deleteFromCartBtn;

        public CartPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.cartProdcutsList = By.CssSelector("tbody tr");
            this.productQuantity = By.CssSelector("td[class='cart_quantity']");
            this.productPrice = By.CssSelector("td[class='cart_price']");
            this.productTotal = By.CssSelector("td[class='cart_total']");
            this.proceedToCheckoutBtn = By.CssSelector("a[class='btn btn-default check_out']");
            this.productDescription = By.CssSelector("td[class='cart_description']");
            this.deleteFromCartBtn = By.CssSelector("a[class='cart_quantity_delete']");
        }

        public void VerifyCartUrl()
        {
            ValidateUrl("cart");
        }

        public void VerifyCartProductCount(int productCount)
        {
            IList<IWebElement> productsInCart = driver.FindElements(cartProdcutsList);
            Assert.That(productsInCart.Count(), Is.EqualTo(productCount));
        }

        public void VerifyCartProductInfo()
        {
            IList<IWebElement> productsInCart = driver.FindElements(cartProdcutsList);
            foreach (IWebElement product in productsInCart)
            {
                string quantityText = product.FindElement(productQuantity).Text;
                string priceText = product.FindElement(productPrice).Text.Replace("Rs. ", "");
                string totalText = product.FindElement(productTotal).Text.Replace("Rs. ", "");

                int.TryParse(quantityText, out int quantity);
                int.TryParse(priceText, out int price);
                int.TryParse(totalText, out int total);

                //verifico que canitdad por precio es igual al total de cada producto
                Assert.That(quantity * price, Is.EqualTo(total));
            }
        }

        public void VerifyCartProductQuantity(int value)
        {
            string quantityText = driver.FindElement(productQuantity).Text;
            int.TryParse(quantityText, out int quantity);

            Assert.That(quantity, Is.EqualTo(value));
        }

        public void ClickOnProceedToCheckout()
        {
            ClickOnElement(proceedToCheckoutBtn);
        }

        public void DeleteItemFromCartByName(string itemName)
        {
            IList<IWebElement> productsInCart = driver.FindElements(cartProdcutsList);
            foreach(IWebElement product in productsInCart)
            {
                string productName = product.FindElement(productDescription).Text;
                IWebElement deleteItemBtn = product.FindElement(deleteFromCartBtn);
                if (productName.Contains(itemName))
                {
                    deleteItemBtn.Click();
                    wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.InvisibilityOfElementLocated(By.XPath($"//*[contains(text(), '{itemName}')]")));
                    break;
                }
            }
        }

        public void VerifyItemNotOnCartByName(string itemName)
        {
            IList<IWebElement> productsInCart = driver.FindElements(cartProdcutsList);
            foreach (IWebElement product in productsInCart)
            {
                string productName = product.FindElement(productDescription).Text;
                Assert.That(productName, Does.Not.Contain(itemName));
            }
        }
    }
}

using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class ProductsPage : Base
    {

        public readonly By productsContainer;
        public readonly By productsList;
        public readonly By productSearchInput;
        public readonly By productSearchSubmitBtn;
        public readonly By productSearchTitle;
        public readonly By productOnHoverContent;
        public readonly By onHoverAddToCartBtn;
        public readonly By addedToCartModalDiscardBtn;
        public readonly By viewCartBtn;
        public readonly By brandsTitlesContainer;
        public readonly By brandsList;
        public string brandName = "";
        public int itemCount = 0;

        public ProductsPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
 ;          this.productsContainer = By.CssSelector("div[class='features_items']");
            this.productsList = By.CssSelector("div[class='features_items'] div[class='col-sm-4']");
            this.productSearchInput = By.Id("search_product");
            this.productSearchSubmitBtn = By.Id("submit_search");
            this.productSearchTitle = By.CssSelector("h2[class='title text-center']");
            this.productOnHoverContent = By.CssSelector("div[class='overlay-content']");
            this.onHoverAddToCartBtn = By.CssSelector("div[class='overlay-content'] a[class='btn btn-default add-to-cart']");
            this.addedToCartModalDiscardBtn = By.CssSelector("div[class='modal-content'] button");
            this.viewCartBtn = By.CssSelector("div[class='modal-content'] a[href='/view_cart']");
            this.brandsTitlesContainer = By.CssSelector("div[class='brands_products']");
            this.brandsList = By.CssSelector("div[class='brands_products'] ul li a");
        }

        public void VerifyProductsPageUrl()
        {
            ValidateUrl("products");
        }

        public void VerifyProductsListIsVisible()
        {
            VerifyElementIsVisibleByLocator(productsContainer);
        }

        public void ClickOnProductByIndex(int index)
        {
            ClickOnElement(By.CssSelector($"a[href='/product_details/{index}']"));
        }

        public void searchProductByName(string productName)
        {
            WriteOnElement(productSearchInput, productName);
            ClickOnElement(productSearchSubmitBtn);
        }

        public void VerifySearchedProductsIsVisible(string title)
        {
            ValidateUrl("search");
            ValidateMsg(productSearchTitle, title);
        }

        public void VerifyProductsAreRelatedToSearchTerm(string searchTerm)
        {
            IList<IWebElement> searchedProducts = driver.FindElements(productsList);
            foreach (IWebElement element in searchedProducts)
            {
                ValidateElementTextContent(element, searchTerm);
            }
        }

        public void AddProductToCartByIndex(int index)
        {
            IList<IWebElement> products = driver.FindElements(productsList);
            HoverOverElement(products[index - 1]);
            products[index - 1].FindElement(onHoverAddToCartBtn).Click();
        }

        public void DiscardModal()
        {
            VerifyElementIsVisibleByLocator(addedToCartModalDiscardBtn);
            ClickOnElement(addedToCartModalDiscardBtn);
        }

        public void VerifyBrandsTitlesContainerIsVisible()
        {
            VerifyElementIsVisibleByLocator(brandsTitlesContainer);
        }

        public void AccessRandomBrand()
        {
            Random random = new Random();

            IList<IWebElement> brands = driver.FindElements(brandsList);

            int index = random.Next(0, brands.Count);

            string pattern = @"\(\d+\)";

            brandName = Regex.Replace(brands[index].Text, pattern, "").Trim();
            brands[index].Click();
        }

        public void VerifyBrandTitle()
        {
            ValidateMsg(productSearchTitle, brandName);
        }

        public void AddAllProductsToCart()
        {
            IList<IWebElement> products = driver.FindElements(productsList);
            itemCount = products.Count;
            foreach (IWebElement product in products)
            {
                HoverOverElement(product);
                HoverOverElement(product.FindElement(onHoverAddToCartBtn));
                product.FindElement(onHoverAddToCartBtn).Click();
                DiscardModal();
            }
        }

    }
}

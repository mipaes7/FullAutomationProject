using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase20SearchProductsandVerifyCartAfterLoginTest : Base
    {

        [TestCase(TestName = "TestCase20SearchProductsandVerifyCartAfterLogin")]

        public void TestCase20SearchProductsandVerifyCartAfterLogin()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Products' button
            landingPage.ClickOnProductsBtn();

            //Verify user is navigated to ALL PRODUCTS page successfully
            productsPage.VerifyProductsPageUrl();

            //Enter product name in search input and click search button
            productsPage.searchProductByName("jeans");

            //Verify 'SEARCHED PRODUCTS' is visible
            productsPage.VerifySearchedProductsIsVisible("SEARCHED PRODUCTS");

            //Verify all the products related to search are visible
            productsPage.VerifyProductsAreRelatedToSearchTerm("jeans");

            //Add those products to cart
            productsPage.AddAllProductsToCart();

            //Click 'Cart' button and verify that products are visible in cart
            landingPage.ClickOnCartBtn();

            //Click 'Signup / Login' button and submit login details
            landingPage.ClickOnAuthBtn();
            authPage.LoginUser(ConfigurationManager.AppSettings["UserEmail"], ConfigurationManager.AppSettings["Password"]);

            //Again, go to Cart page
            landingPage.ClickOnCartBtn();

            //Verify that those products are visible in cart after login as well
            cartPage.VerifyCartProductCount(productsPage.itemCount);
        }

    }
}

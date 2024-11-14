using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase13VerifyProductQuantityinCartTest : Base
    {

        [TestCase(TestName = "TestCase13VerifyProductQuantityinCart")]

        public void TestCase13VerifyProductQuantityinCart()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click 'View Product' for any product on home page
            productsPage.ClickOnProductByIndex(1);

            //Verify product detail is opened
            productDetailsPage.VerifyProductDetailsPageUrl();

            //Increase quantity to 4
            productDetailsPage.ChangeProductQuantity(4);

            //Click 'Add to cart' button
            productDetailsPage.ClickOnAddToCart();

            //Click 'View Cart' button
            productsPage.DiscardModal();
            landingPage.ClickOnCartBtn();

            //Verify that product is displayed in cart page with exact quantity
            cartPage.VerifyCartProductQuantity(4);
        }
    }
}

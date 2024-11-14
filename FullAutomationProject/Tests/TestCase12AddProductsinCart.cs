using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase12AddProductsinCartTest : Base
    {

        [TestCase(TestName = "TestCase12AddProductsinCart")]

        public void TestCase12AddProductsinCart()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Products' button
            landingPage.ClickOnProductsBtn();

            //Hover over first product and click 'Add to cart'
            productsPage.AddProductToCartByIndex(1);

            //Click 'Continue Shopping' button
            productsPage.DiscardModal();

            //Hover over second product and click 'Add to cart'
            productsPage.AddProductToCartByIndex(2);

            //Click 'View Cart' button
            productsPage.DiscardModal();
            landingPage.ClickOnCartBtn();

            //Verify both products are added to Cart
            cartPage.VerifyCartProductCount(2);

            //Verify their prices, quantity and total price
            cartPage.VerifyCartProductInfo();
        }

    }
}

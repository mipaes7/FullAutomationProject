using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase17RemoveProductsFromCartTest : Base
    {

        [TestCase(TestName = "TestCase17RemoveProductsFromCart")]

        public void TestCase17RemoveProductsFromCart()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Add products to cart
            productsPage.AddProductToCartByIndex(1);
            productsPage.DiscardModal();
            productsPage.AddProductToCartByIndex(2);

            //Click 'Cart' button
            productsPage.DiscardModal();
            landingPage.ClickOnCartBtn();

            //Verify that cart page is displayed
            cartPage.VerifyCartUrl();

            //Click 'X' button corresponding to particular product
            cartPage.DeleteItemFromCartByName("Blue Top");

            //Verify that product is removed from the cart
            cartPage.VerifyItemNotOnCartByName("Blue Top");
        }

    }
}

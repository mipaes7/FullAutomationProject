using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase22AddtoCartFromRecommendedItemsTest : Base
    {

        [TestCase (TestName = "TestCase22AddtoCartFromRecommendedItems")]

        public void TestCase22AddtoCartFromRecommendedItems()
        {

            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Scroll to bottom of page
            landingPage.ScrollToRecommendedProducts();

            //Verify 'RECOMMENDED ITEMS' are visible
            landingPage.VerifyRecommendedProductsIsVisible();

            //Click on 'Add To Cart' on Recommended product
            landingPage.AddRecommendedProductByName("Blue Top");
            productsPage.DiscardModal();

            //Click on 'View Cart' button
            landingPage.ClickOnCartBtn();

            //Verify that product is displayed in cart page
            cartPage.VerifyItemOnCartByName("Blue Top");
        }

    }
}

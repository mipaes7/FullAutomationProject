using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase8VerifyAllProductsAndProductDetailPageTest : Base
    {

        [TestCase(TestName = "TestCase8VerifyAllProductsAndProductDetailPage")]

        public void TestCase8VerifyAllProductsAndProductDetailPage()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Products' button
            landingPage.ClickOnProductsBtn();

            //Verify user is navigated to ALL PRODUCTS page successfully
            productsPage.VerifyProductsPageUrl();

            //The products list is visible
            productsPage.VerifyProductsListIsVisible();

            //Click on 'View Product' of first product
            productsPage.ClickOnProductByIndex(1);

            //Verify User is landed to product detail page
            productDetailsPage.VerifyProductDetailsPageUrl();

            //Verify that detail detail is visible: product name, category, price, availability, condition, brand
            productDetailsPage.VerifyProductDetailsInfoIsVisible();

        }

    }
}

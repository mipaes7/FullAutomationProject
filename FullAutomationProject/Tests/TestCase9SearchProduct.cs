using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase9SearchProductTest : Base
    {

        [TestCase (TestName = "TestCase9SearchProduct")]
        
        public void TestCase9SearchProduct()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver, wait, actions);

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

        }

    }
}

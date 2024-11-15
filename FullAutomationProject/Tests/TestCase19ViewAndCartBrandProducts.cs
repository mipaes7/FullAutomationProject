using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase19ViewAndCartBrandProductsTest : Base
    {

        [TestCase(TestName = "TestCase19ViewAndCartBrandProducts")]

        public void TestCase19ViewAndCartBrandProducts()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            BrandPage brandPage = new BrandPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Click on 'Products' button
            landingPage.ClickOnProductsBtn();

            //Verify that Brands are visible on left side bar
            productsPage.VerifyBrandsTitlesContainerIsVisible();

            //Click on any brand name
            productsPage.AccessRandomBrand();

            //Verify that user is navigated to brand page and brand products are displayed
            brandPage.VerifyBrandPageUrl();

            //On left side bar, click on any other brand link
            productsPage.AccessRandomBrand();
            
            //Verify that user is navigated to that brand page and can see products
            productsPage.VerifyBrandTitle();
        }

    }
}

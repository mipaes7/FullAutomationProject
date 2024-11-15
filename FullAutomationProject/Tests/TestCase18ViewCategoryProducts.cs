using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase18ViewCategoryProductsTest : Base
    {

        [TestCase(TestName = "TestCase18ViewCategoryProducts")]

        public void TestCase18ViewCategoryProducts()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            CategoryPage categoryPage = new CategoryPage(driver, wait, actions);

            landingPage.ClickOnConsentBtn();

            //Verify that categories are visible on left side bar
            landingPage.VerifyCategoriesContainerIsVisible();

            //Click on 'Women' category
            landingPage.ClickOnCategoryByTitle("WOMEN");

            //Click on any category link under 'Women' category, for example: Dress
            landingPage.ClickOnAccordionItemByName("DRESS");

            //Verify that category page is displayed and confirm text 'WOMEN - DRESS PRODUCTS'
            categoryPage.VerifyCategoryPageUrl();
            categoryPage.VerifyCategoryPageTitle("WOMEN -  DRESS PRODUCTS");

            //On left side bar, click on any sub-category link of 'Men' category
            landingPage.ClickOnCategoryByTitle("MEN");
            landingPage.ClickOnAccordionItemByName("TSHIRTS");

            //Verify that user is navigated to that category page
            categoryPage.VerifyCategoryPageUrl();
        }

    }
}

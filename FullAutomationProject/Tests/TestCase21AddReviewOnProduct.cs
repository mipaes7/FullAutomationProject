using FullAutomationProject.Builders;
using FullAutomationProject.PageObjects;
using FullAutomationProject.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase21AddReviewOnProductTest : Base
    {

        [TestCase(TestName = "TestCase21AddReviewOnProduct")]

        public void TestCase21AddReviewOnProduct()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            ProductDetailsPage productDetailsPage = new ProductDetailsPage(driver, wait, actions);

            ReviewBuilder reviewBuilder = new ReviewBuilder();
            Review review = reviewBuilder
                .WithName("Alice Smith")
                .WithEmailAddress("alice@example.com")
                .WithReviewText("This product is amazing! Highly recommended.")
                .Build();

            landingPage.ClickOnConsentBtn();

            //Click on 'Products' button
            landingPage.ClickOnProductsBtn();

            //Verify user is navigated to ALL PRODUCTS page successfully
            productsPage.VerifyProductsPageUrl();

            //Click on 'View Product' button
            productsPage.ClickOnProductByIndex(1);

            //Verify 'Write Your Review' is visible
            productDetailsPage.VerifyReviewContainerIsVisible();

            //Enter name, email and review
            productDetailsPage.FillReviewForm(ReviewFields.Name, review.Name);
            productDetailsPage.FillReviewForm(ReviewFields.EmailAddress, review.EmailAddress);
            productDetailsPage.FillReviewForm(ReviewFields.Review, review.ReviewText);

            //Click 'Submit' button
            productDetailsPage.ClickOnSubmitReview();

            //Verify success message 'Thank you for your review.'
            productDetailsPage.VerifyReviewSuccesAlertIsVisible();
        }

    }
}

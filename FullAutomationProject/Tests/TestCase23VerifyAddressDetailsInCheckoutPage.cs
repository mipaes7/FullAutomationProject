using FullAutomationProject.Builders;
using FullAutomationProject.Enums;
using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase23VerifyAddressDetailsInCheckoutPageTest : Base 
    {
        [TestCase (TestName = "TestCase23VerifyAddressDetailsInCheckoutPage")]

        public void TestCase23VerifyAddressDetailsInCheckoutPage()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            RegisterPage registerPage = new RegisterPage(driver, wait, actions);
            CreatedAccPage createdAccPage = new CreatedAccPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);
            CheckoutPage checkoutPage = new CheckoutPage(driver, wait, actions);
            DeletedAccPage deletedAccPage = new DeletedAccPage(driver, wait, actions);

            UserDetailsBuilder userDetailsBuilder = new UserDetailsBuilder();
            UserDetails user = userDetailsBuilder
                .WithName("username3")
                .WithEmail("email13@email")
                .WithPassword("123456")
                .WithDayOfBirth("15")
                .WithMonthOfBirth("September")
                .WithYearOfBirth("1990")
                .WithFirstName("John")
                .WithLastName("Doe")
                .WithCompany("Example Corp")
                .WithAddress("123 Main St")
                .WithAddress2("Apt 4B")
                .WithCountry("United States")
                .WithState("New York")
                .WithCity("New York")
                .WithZipCode("10001")
                .WithPhone("555-1234")
                .Build();

            landingPage.ClickOnConsentBtn();
            
            //Click 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Fill all details in Signup and create account
            authPage.SignUpUser(user.Name, user.Email);
            authPage.ClickOnSignUpBtn();
            registerPage.ClickGenderRadio();
            registerPage.FillRegistrationForm(AccountInfoFields.Password, user.Password);
            registerPage.FillRegistrationForm(AccountInfoFields.DayofBirth, user.DayOfBirth);
            registerPage.FillRegistrationForm(AccountInfoFields.MonthofBirth, user.MonthOfBirth);
            registerPage.FillRegistrationForm(AccountInfoFields.YearofBirth, user.YearOfBirth);
            registerPage.ClickSignUpCheckBoxes();
            registerPage.FillRegistrationForm(AccountInfoFields.FirstName, user.FirstName);
            registerPage.FillRegistrationForm(AccountInfoFields.LastName, user.LastName);
            registerPage.FillRegistrationForm(AccountInfoFields.Company, user.Company);
            registerPage.FillRegistrationForm(AccountInfoFields.Address, user.Address);
            registerPage.FillRegistrationForm(AccountInfoFields.Address2, user.Address2);
            registerPage.FillRegistrationForm(AccountInfoFields.Country, user.Country);
            registerPage.FillRegistrationForm(AccountInfoFields.State, user.State);
            registerPage.FillRegistrationForm(AccountInfoFields.City, user.City);
            registerPage.FillRegistrationForm(AccountInfoFields.ZipCode, user.ZipCode);
            registerPage.FillRegistrationForm(AccountInfoFields.Phone, user.Phone);
            registerPage.ClickOnCreateAcc();

            //Verify 'ACCOUNT CREATED!' and click 'Continue' button
            createdAccPage.VerifyCreatedAccountBannerIsVisible();
            createdAccPage.ClickOnContinueBtn();

            //Verify 'Logged in as username' at top
            landingPage.VerifyLoggedAsUserMsgIsVisible();

            //Add products to cart
            productsPage.AddProductToCartByIndex(1);


            //Click 'Cart' button
            productsPage.DiscardModal();
            landingPage.ClickOnCartBtn();

            //Verify that cart page is displayed
            cartPage.VerifyCartUrl();

            //Click Proceed To Checkout
            cartPage.ClickOnProceedToCheckout();

            //Verify that the delivery address is same address filled at the time of registration of account
            checkoutPage.VerifyCheckoutAddressInfo(CheckoutAddressInfoFields.Address1, user.Address);
            checkoutPage.VerifyCheckoutAddressInfo(CheckoutAddressInfoFields.Address2, user.Address2);
            checkoutPage.VerifyCheckoutAddressInfo(CheckoutAddressInfoFields.FullAddress, $"{user.City} {user.State}");

            //Verify that the billing address is same address filled at the time of registration of account
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Address1, user.Address);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Address2, user.Address2);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.FullAddress, $"{user.City} {user.State}");

            //Click 'Delete Account' button
            landingPage.ClickOnDeleteAccBtn();

            //Verify 'ACCOUNT DELETED!' and click 'Continue' button
            deletedAccPage.VerifyDeletedAccMsgIsVisible();

        }


    }
}

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
    internal class TestCase14PlaceOrderRegisterwhileCheckoutTest : Base
    {

        [TestCase(TestName = "TestCase14PlaceOrderRegisterwhileCheckout")]

        public void TestCase14PlaceOrderRegisterwhileCheckout()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            RegisterPage registerPage = new RegisterPage(driver, wait, actions);
            ProductsPage productsPage = new ProductsPage(driver, wait, actions);
            CartPage cartPage = new CartPage(driver, wait, actions);
            CreatedAccPage createdAccPage = new CreatedAccPage(driver, wait, actions);
            CheckoutPage checkoutPage = new CheckoutPage(driver, wait, actions);
            PaymentPage paymentPage = new PaymentPage(driver, wait, actions);
            DeletedAccPage deletedAccPage = new DeletedAccPage(driver, wait, actions);

            UserDetailsBuilder userDetailsBuilder = new UserDetailsBuilder();
            UserDetails user = userDetailsBuilder
                .WithName("janesmith124")
                .WithEmail("jane.smith241@example.com")
                .WithPassword("mySecurePassword456")
                .WithDayOfBirth("22")
                .WithMonthOfBirth("March")
                .WithYearOfBirth("1985")
                .WithFirstName("Jane")
                .WithLastName("Smith")
                .WithCompany("Tech Innovations Inc.")
                .WithAddress("456 Elm St")
                .WithAddress2("Suite 101")
                .WithCountry("Canada")
                .WithState("Ontario")
                .WithCity("Toronto")
                .WithZipCode("M5V2T6")
                .WithPhone("416-555-7890")
                .Build();

            CreditCardBuilder creditCardBuilder = new CreditCardBuilder();
            CreditCard creditCard = creditCardBuilder
                .WithNameOnCard("John Doe")
                .WithCardNumber("1234567812345678")
                .WithCardPINCode("1234")
                .WithCardExpirationDateMM("12")
                .WithCardExpirationDateYYYY("2030")
                .Build();


            landingPage.ClickOnConsentBtn();

            //Add products to cart
            productsPage.AddProductToCartByIndex(1);

            //Click 'Cart' button
            productsPage.DiscardModal();
            landingPage.ClickOnCartBtn();

            //Verify that cart page is displayed
            cartPage.VerifyCartUrl();

            //Click Proceed To Checkout
            cartPage.ClickOnProceedToCheckout();

            //Click 'Register / Login' button
            productsPage.DiscardModal();
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

            //Verify ' Logged in as username' at top
            landingPage.VerifyLoggedAsUserMsgIsVisible();

            //Click 'Cart' button
            landingPage.ClickOnCartBtn();

            //Click 'Proceed To Checkout' button
            cartPage.ClickOnProceedToCheckout();

            //Verify Address Details and Review Your Order
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Fullname, $"{user.FirstName} {user.LastName}");
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Company, user.Company);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Address1, user.Address);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Address2, user.Address2);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.FullAddress, $"{user.City} {user.State}");
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Country, user.Country);
            checkoutPage.VerifyInvoiceInfo(CheckoutAddressInfoFields.Phone, user.Phone);

            //Enter description in comment text area and click 'Place Order'
            checkoutPage.EnterOrderComment("comment");
            checkoutPage.ClickOnPlaceOrder();

            //Enter payment details: Name on Card, Card Number, CVC, Expiration date
            paymentPage.FillCreditCardInfo(CreditCardFields.NameOnCard, creditCard.NameOnCard);
            paymentPage.FillCreditCardInfo(CreditCardFields.CardNumber, creditCard.CardNumber);
            paymentPage.FillCreditCardInfo(CreditCardFields.CardPINCode, creditCard.CardPINCode);
            paymentPage.FillCreditCardInfo(CreditCardFields.CardExpirationDateMM, creditCard.CardExpirationDateMM);
            paymentPage.FillCreditCardInfo(CreditCardFields.CardExpirationDateYYYY, creditCard.CardExpirationDateYYYY);

            //Click 'Pay and Confirm Order' button
            paymentPage.ClickOnConfirmOrder();

            //Verify success message 'Your order has been placed successfully!'
            //paymentPage.VerifySuccesfulPaymentAlert("Your order has been placed successfully!");

            //Click 'Delete Account' button
            landingPage.ClickOnDeleteAccBtn();

            //Verify 'ACCOUNT DELETED!' and click 'Continue' button
            deletedAccPage.VerifyDeletedAccMsgIsVisible();
        }

    }
}

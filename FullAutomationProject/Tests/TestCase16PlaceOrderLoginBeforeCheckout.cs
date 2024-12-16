using FullAutomationProject.Builders;
using FullAutomationProject.Enums;
using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    internal class TestCase16PlaceOrderLoginBeforeCheckoutTest : Base
    {

        [TestCase(TestName = "TestCase16PlaceOrderLoginBeforeCheckout")]

        public void TestCase16PlaceOrderLoginBeforeCheckout()
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

            CreditCardBuilder creditCardBuilder = new CreditCardBuilder();
            CreditCard creditCard = creditCardBuilder
                .WithNameOnCard("John Doe")
                .WithCardNumber("1234567812345678")
                .WithCardPINCode("1234")
                .WithCardExpirationDateMM("12")
                .WithCardExpirationDateYYYY("2030")
                .Build();

            landingPage.ClickOnConsentBtn();



            //Click 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Fill email, password and click 'Login' button
            authPage.LoginUser(ConfigurationManager.AppSettings["UserEmail"], ConfigurationManager.AppSettings["Password"]);

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
            //paymentPage.VerifySuccessfulPaymentAlert("Your order has been placed successfully!");

            ////Click 'Delete Account' button
            //landingPage.ClickOnDeleteAccBtn();

            ////Verify 'ACCOUNT DELETED!' and click 'Continue' button
            //deletedAccPage.VerifyDeletedAccMsgIsVisible();

        }

    }
}

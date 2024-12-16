using FullAutomationProject.Enums;
using FullAutomationProject.Builders;
using FullAutomationProject.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.Tests
{
    class TestCase1RegisterUserTest : Base
    {
        [TestCase(TestName = "TestCase1RegisterUser")]
        public void TestCase1RegisterUser()
        {
            LandingPage landingPage = new LandingPage(driver, wait, actions);
            AuthPage authPage = new AuthPage(driver, wait, actions);
            RegisterPage registerPage = new RegisterPage(driver, wait, actions);
            CreatedAccPage createdAccPage = new CreatedAccPage(driver, wait, actions);
            DeletedAccPage deletedAccPage = new DeletedAccPage(driver, wait, actions);

            UserDetailsBuilder userDetailsBuilder = new UserDetailsBuilder();
            UserDetails user = userDetailsBuilder
                .WithName("username78")
                .WithEmail("email178@email")
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

            //Verify that home page is visible successfully

            //Click on 'Signup / Login' button
            landingPage.ClickOnAuthBtn();

            //Verify 'New User Signup!' is visible
            authPage.VerifySignUpBannerIsVisible();

            //Enter name and email address
            authPage.SignUpUser(user.Name, user.Email);

            //Click 'Signup' button
            authPage.ClickOnSignUpBtn();

            //Verify that 'ENTER ACCOUNT INFORMATION' is visible
            registerPage.VerifyRegistrationBannerIsVisible();

            //Fill details: Title, Name, Email, Password, Date of birth
            registerPage.ClickGenderRadio();
            registerPage.FillRegistrationForm(AccountInfoFields.Password, user.Password);
            registerPage.FillRegistrationForm(AccountInfoFields.DayofBirth, user.DayOfBirth);
            registerPage.FillRegistrationForm(AccountInfoFields.MonthofBirth, user.MonthOfBirth);
            registerPage.FillRegistrationForm(AccountInfoFields.YearofBirth, user.YearOfBirth);

            //Select checkbox 'Sign up for our newsletter!'
            //Select checkbox 'Receive special offers from our partners!'
            registerPage.ClickSignUpCheckBoxes();

            //Fill details: First name, Last name, Company, Address, Address2, Country, State, City, Zipcode, Mobile Number
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

            //Click 'Create Account button'
            registerPage.ClickOnCreateAcc();

            //Verify that 'ACCOUNT CREATED!' is visible
            createdAccPage.VerifyCreatedAccountBannerIsVisible();

            //Click 'Continue' button
            createdAccPage.ClickOnContinueBtn();

            //Verify that 'Logged in as username' is visible
            landingPage.VerifyLoggedAsUserMsgIsVisible();

            //Click 'Delete Account' button
            //landingPage.ClickOnDeleteAccBtn();

            //Verify that 'ACCOUNT DELETED!' is visible and click 'Continue' button
            //deletedAccPage.VerifyDeletedAccMsgIsVisible();
        }
    }
}

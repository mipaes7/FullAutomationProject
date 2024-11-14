using FullAutomationProject.Enums;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject.PageObjects
{
    internal class RegisterPage : Base
    {
        public readonly By registrationBanner;
        public readonly By genderRadio;
        public readonly By passwordInput;
        public readonly By dayOfBirthInput;
        public readonly By monthOfBirthInput;
        public readonly By yearOfBirthInput;
        public readonly By checkboxes;
        public readonly By firstNameInput;
        public readonly By lastNameInput;
        public readonly By companyInput;
        public readonly By addressInput;
        public readonly By address2Input;
        public readonly By countryInput;
        public readonly By stateInput;
        public readonly By cityInput;
        public readonly By zipInput;
        public readonly By phoneInput;
        public readonly By createAccBtn;

        public RegisterPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.registrationBanner = By.CssSelector("div[class='login-form'] h2.title:first-child b");
            this.genderRadio = By.Id("id_gender1");
            this.passwordInput = By.Id("password");
            this.dayOfBirthInput = By.Id("days");
            this.monthOfBirthInput = By.Id("months");
            this.yearOfBirthInput = By.Id("years");
            this.checkboxes = By.CssSelector("div[class='checkbox']");
            this.firstNameInput = By.Id("first_name");
            this.lastNameInput = By.Id("last_name");
            this.companyInput = By.Id("company");
            this.addressInput = By.Id("address1");
            this.address2Input = By.Id("address2");
            this.countryInput = By.Id("country");
            this.stateInput = By.Id("state");
            this.cityInput = By.Id("city");
            this.zipInput = By.Id("zipcode");
            this.phoneInput = By.Id("mobile_number");
            this.createAccBtn = By.CssSelector(" section button[type='submit']");
        }

        public void VerifyRegistrationBannerIsVisible()
        {
            VerifyElementIsVisibleByLocator(registrationBanner);
        }

        public By GetSignUpFormField(AccountInfoFields field)
        {
            By inputField = null;

            switch(field)
            {
                case AccountInfoFields.Password:
                    inputField = passwordInput;
                    break;
                case AccountInfoFields.FirstName:
                    inputField = firstNameInput; 
                    break;
                case AccountInfoFields.LastName:
                    inputField = lastNameInput;
                    break;
                case AccountInfoFields.Company:
                    inputField = companyInput;
                    break;
                case AccountInfoFields.Address:
                    inputField = addressInput;
                    break;
                case AccountInfoFields.Address2:
                    inputField = address2Input;
                    break;
                case AccountInfoFields.Country:
                    inputField = countryInput;
                    break;
                case AccountInfoFields.State:
                    inputField = stateInput;
                    break;
                case AccountInfoFields.City:
                    inputField = cityInput;
                    break;
                case AccountInfoFields.ZipCode:
                    inputField = zipInput;
                    break;
                case AccountInfoFields.Phone:
                    inputField = phoneInput;
                    break;
                case AccountInfoFields.DayofBirth:
                    inputField = dayOfBirthInput;
                    break;
                case AccountInfoFields.MonthofBirth:
                    inputField = monthOfBirthInput;
                    break;
                case AccountInfoFields.YearofBirth:
                    inputField = yearOfBirthInput;
                    break;
            }

            return inputField;
        }

        public void FillRegistrationForm(AccountInfoFields field, string text)
        {
            By inputField = GetSignUpFormField(field);

            if (field == AccountInfoFields.Country || field == AccountInfoFields.DayofBirth || field == AccountInfoFields.MonthofBirth || field == AccountInfoFields.YearofBirth)
            {
                Select(inputField, text);
            }
            else
            {
                WriteOnElement(inputField, text);
            }
        }

        public void ClickGenderRadio()
        {
            ClickOnElement(genderRadio);
        }

        public void ClickSignUpCheckBoxes()
        {
            IList<IWebElement> checkboxesList = driver.FindElements(checkboxes);
            foreach (IWebElement checkbox in checkboxesList)
            {
                checkbox.Click();
            }
        }

        public void ClickOnCreateAcc()
        {
            ClickOnElement(createAccBtn);
        }


    }
}

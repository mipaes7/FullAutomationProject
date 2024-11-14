﻿using FullAutomationProject.Enums;
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
    internal class CheckoutPage : Base
    {

        public readonly By invoiceName;
        public readonly By invoiceCompany;
        public readonly By invoiceAddress1;
        public readonly By invoiceAddress2;
        public readonly By invoiceFullAddress;
        public readonly By invoiceCountry;
        public readonly By invoicePhone;
        public readonly By orderCommentary;
        public readonly By placeOrderBtn;

        public CheckoutPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.invoiceName = By.CssSelector("ul[id='address_invoice'] li:nth-child(2)");
            this.invoiceCompany = By.CssSelector("ul[id='address_invoice'] li:nth-child(3)");
            this.invoiceAddress1 = By.CssSelector("ul[id='address_invoice'] li:nth-child(4)");
            this.invoiceAddress2 = By.CssSelector("ul[id='address_invoice'] li:nth-child(5)");
            this.invoiceFullAddress = By.CssSelector("ul[id='address_invoice'] li:nth-child(6)");
            this.invoiceCountry = By.CssSelector("ul[id='address_invoice'] li:nth-child(7)");
            this.invoicePhone = By.CssSelector("ul[id='address_invoice'] li:nth-child(8)");
            this.orderCommentary = By.CssSelector("textarea");
            this.placeOrderBtn = By.CssSelector("a[href='/payment']");
        }

        public By GetInvoiceField(CheckoutAddressInfoFields field)
        {
            By infoField = null;

            switch (field)
            {
                case CheckoutAddressInfoFields.Fullname:
                    infoField = invoiceName; 
                    break;
                case CheckoutAddressInfoFields.Company:
                    infoField = invoiceCompany;
                    break;
                case CheckoutAddressInfoFields.Address1:
                    infoField = invoiceAddress1;
                    break;
                case CheckoutAddressInfoFields.Address2:
                    infoField = invoiceAddress2;
                    break;
                case CheckoutAddressInfoFields.FullAddress:
                    infoField = invoiceFullAddress;
                    break;
                case CheckoutAddressInfoFields.Country:
                    infoField = invoiceCountry;
                    break;
                case CheckoutAddressInfoFields.Phone:
                    infoField = invoicePhone;
                    break;
            }

            return infoField;
        }

        public void VerifyInvoiceInfo(CheckoutAddressInfoFields field, string text)
        {
            By invoiceField = GetInvoiceField(field);

            ValidateMsg(invoiceField, text);
        }

        public void EnterOrderComment(string comment)
        {
            WriteOnElement(orderCommentary, comment);
        }

        public void ClickOnPlaceOrder()
        {
            ClickOnElement(placeOrderBtn);
        }
    }
}

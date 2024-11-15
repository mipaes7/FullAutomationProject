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
    internal class CategoryPage : Base
    {
        public readonly By categoryPageTitle;

        public CategoryPage(IWebDriver driver, WebDriverWait wait, Actions actions)
        {
            this.driver = driver;
            this.wait = wait;
            this.actions = actions;
            this.categoryPageTitle = By.CssSelector("div[class='features_items'] h2[class='title text-center']");
        }

        public void VerifyCategoryPageUrl()
        {
            ValidateUrl("category");
        }

        public void VerifyCategoryPageTitle(string categoryTitle)
        {
            ValidateMsg(categoryPageTitle, categoryTitle);
        }

    }
}

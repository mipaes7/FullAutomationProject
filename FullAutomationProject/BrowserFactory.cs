using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FullAutomationProject
{
    internal class BrowserFactory
    {

        public static IWebDriver InitWebBrowser(string browserName)
        {
            IWebDriver driver = null;

            string bravePath = @"C:\\Users\\MPardal\\AppData\\Local\\BraveSoftware\\Brave-Browser\\Application\\brave.exe";

            switch (browserName)
            {
                case "Chrome":
                    var chromeOptions = new ChromeOptions();
                    chromeOptions.BinaryLocation = bravePath;
                    driver = new ChromeDriver(chromeOptions);
                    break;
                case "Edge":
                    var edgeOptions = new EdgeOptions();
                    driver = new EdgeDriver(edgeOptions);
                    break;
                case "Firefox":
                    var firefoxOptions = new FirefoxOptions();
                    driver = new FirefoxDriver(firefoxOptions);
                    break;
            }

            return driver;
        }

    }
}

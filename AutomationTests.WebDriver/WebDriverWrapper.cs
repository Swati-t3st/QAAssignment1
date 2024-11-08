using AutomationTests.Helpers;
using AutomationTests.Support;
using AutomationTests.WebDriver.Extension;
using AutomationTests.WebDriver.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;

namespace AutomationTests.Logging
{
    public class WebDriverWrapper : IWebDriverWrapper
    {
        private readonly IWebDriver _driver;

        public WebDriverWrapper(DriverConfig config, TimeSpan? commandTimeout = null)
        {
            _driver = Initialise(config.DriverType, config.DriverPath, commandTimeout);
        }

        public IWebDriver GetDriver() => _driver;

        public bool CheckIfElementExists(string xpath) => _driver?.CheckIfElementExists(By.XPath(xpath)) ?? false;

        public void ClickElement(string xpath) => _driver?.FindElement(By.XPath(xpath)).Click();

        public string GetText(string xpath) => _driver?.FindElement(By.XPath(xpath)).Text;

        public void EnterText(string text, string xpath) => _driver?.FindElement(By.XPath(xpath)).SendKeys(text);

        public void EnterText(string xpath)
        {
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver?.FindElement(By.XPath(xpath))).Click().Perform();
        }

        public IWebElement ReturnFirstElement(string elements)
        {
            IList<IWebElement> result = _driver.FindElements(By.XPath(elements));
            return result[1];
        }

        private IWebDriver Initialise(DriverType driverType, string driverPath, TimeSpan? commandTimeout = null)
        {
            IWebDriver driver;
            if (driverType == DriverType.Chrome)
            {
                var options = new ChromeOptions();
                options.AddArgument("--ignore-certificate-errors");
                driver = new ChromeDriver(options);
            }
            else if (driverType == DriverType.Edge)
            {
                var options = new EdgeOptions();
                options.AddArgument("--ignore-certificate-errors");
                driver = new EdgeDriver(driverPath, options);
            }
            else
            {
                throw new ArgumentException("Unsupported driver type");
            }

            if (commandTimeout != null)
            {
                driver.Manage().Timeouts().PageLoad.Add(commandTimeout.Value);
            }

            return driver;
        }

        public void Navigate(string url)
        {
            _driver?.Navigate().GoToUrl(url);
            try
            {
                var alert = _driver?.SwitchTo().Alert();
                alert?.Accept();
            }
            catch (NoAlertPresentException) { }
            _driver?.Manage().Window.Maximize();
        }
    }
}

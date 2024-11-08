using AutomationTests.Logging;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.WebDriver.Extension
{
    public static class WebDriverExtensions
    {
        public static ILogger Logger { get; private set; }

        public static void SetLogger(ILogger logger) { Logger = logger; }

        public static bool CheckIfElementExists(this IWebDriver driver, By by)
        {
            try
            {
                var element = driver.FindElement(by);
                return element != null;
            }
            catch(NoSuchElementException)
            {
                return false;
            }
        }
    }
}

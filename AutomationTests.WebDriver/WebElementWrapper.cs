using AutomationTests.WebDriver.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTests.Logging
{
    public class WebElementWrapper : IWebElementWrapper
    {
        private readonly IWebDriver _driver;
        private readonly IWebElement _element;

        public WebElementWrapper(IWebElement element, IWebDriver driver)
        {
            _element = element;
            _driver = driver;
        }

        public bool Displayed => _element?.Displayed ?? false;

        public string Text => _element?.Text;

        public void Clear(int? debounce = null) => _element?.Clear();

        public void Click() => _element?.Click();

        public void SendKeys(string keys, int? debounce = null)
        {
            new Actions(_driver).SendKeys(keys).Perform();
        }
    }
}

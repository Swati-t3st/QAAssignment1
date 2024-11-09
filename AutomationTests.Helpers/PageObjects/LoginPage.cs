using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V128.WebAuthn;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Helpers.PageObjects
{
    public class LoginPage : ILoginPage
    {
        private readonly IWebDriver _driver;

        public LoginPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private static class Locators
        {
            public static By Email => By.Id("email");
            public static By Password => By.Id("pass");
            public static By SignInButton => By.Id("send2");
            public static By Home => By.TagName("img");
        }

        // Methods
        public void NavigateToLoginPage()
        {
            _driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/customer/account/login/");
        }

        public void SignIn(string email, string password)
        {
            _driver.FindElement(Locators.Email).SendKeys(email);
            _driver.FindElement(Locators.Password).SendKeys(password);
            _driver.FindElement(Locators.SignInButton).Click();
        }

        public bool IsLoggedIn()
        {
            return _driver.FindElement(Locators.Home).Displayed;
        }
    }
}

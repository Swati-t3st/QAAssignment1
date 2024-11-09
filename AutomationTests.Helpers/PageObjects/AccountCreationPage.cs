using AutomationTests.WebDriver.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

namespace AutomationTests.Helpers
{

    public class AccountPage : IAccount
    {
        private readonly IWebDriver _driver;

        public AccountPage(IWebDriver driver)
        {
            _driver = driver;
        }

        // Locators
        private static class Locators
        {
            public static By FirstName => By.Id("firstname");
            public static By LastName => By.Id("lastname");
            public static By EmailAddress => By.Id("email_address");
            public static By Password => By.Id("password");
            public static By PasswordConfirmation => By.Id("password-confirmation");
            public static By CreateAccountButton => By.CssSelector("button[title='Create an Account']");
            public static By HomePage => By.TagName("img");
        }

        // Methods
        public void NavigateToRegistrationPage()
        {
            _driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/customer/account/create/");
        }

        public void CreateAccount(string email, string password)
        {
            _driver.FindElement(Locators.FirstName).SendKeys("Test");
            _driver.FindElement(Locators.LastName).SendKeys("User");
            _driver.FindElement(Locators.EmailAddress).SendKeys(email);
            _driver.FindElement(Locators.Password).SendKeys(password);
            _driver.FindElement(Locators.PasswordConfirmation).SendKeys(password);
            _driver.FindElement(Locators.CreateAccountButton).Click();
        }

        public bool IsHomePageDisplayed()
        {
          return  _driver.FindElement(Locators.HomePage).Displayed;
        }
    }
}

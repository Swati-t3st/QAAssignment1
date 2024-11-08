using AutomationTests.Helpers;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.WebDriver.Interfaces
{
    public interface IWebDriverWrapper
    {
        void Navigate(string url);

        string GetText(string xpath);
        bool CheckIfElementExists(string xpath);

        void ClickElement(string xpath);

        void EnterText(string text, string xpath);

        void EnterText(string xpath);

        IWebDriver GetDriver();

        IWebElement ReturnFirstElement(string elements);
    }
}

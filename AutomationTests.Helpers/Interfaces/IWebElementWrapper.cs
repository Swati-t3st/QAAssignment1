using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.WebDriver.Interfaces
{
    public interface IWebElementWrapper
    {
        bool Displayed {  get; }
        string Text { get; }    
        void SendKeys(string keys, int? debounce = null);

        void Click();

        void Clear(int? debounce = null);

    }
}

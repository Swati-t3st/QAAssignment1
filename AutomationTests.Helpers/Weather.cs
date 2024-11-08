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
    
    public class WeatherPage : IWeather
    {
        protected readonly IWebDriverWrapper driver;

        public WeatherPage(IWebDriverWrapper driver)
        { 
            this.driver = driver;
        }
        private const string SearchBox = "//input[@id='ls-c-search__input-label']";

        private const string SearchIcon = "//button[contains(@class,'search')]";

        private const string SelectCity = "//div[contains(@class,'search')]/ul[contains(@class,'locations')]/li";

        private const string Tomorrow = "//div[contains(@class,'day-carousel')]/following-sibling::ol/li[2]";

        private const string HighTemp = "//div[contains(@class,'day-carousel')]/following-sibling::ol/li[2]//span[contains(@class,'temperature__high')]/span/span[contains(@class,'--c')]";

        private const string LowTemp = "//div[contains(@class,'day-carousel')]/following-sibling::ol/li[2]//span[contains(@class,'temperature__low')]/span/span[contains(@class,'--c')]";


        public int GetHighTemp()
        {
            var temp  = Regex.Replace(driver.GetText(HighTemp), "[^0-9]", string.Empty);
            return Convert.ToInt32(temp);
        }

        public int GetLowTemp()
        {
            var temp = Regex.Replace(driver.GetText(LowTemp), "[^0-9]", string.Empty);
            return Convert.ToInt32(temp);
        }

        public void SearchCity(string city)
        {
            driver.ClickElement(SearchBox);
            driver.EnterText(city,SearchBox);
            driver.ClickElement(SearchIcon);
            Thread.Sleep(5000);
            driver.ReturnFirstElement(SelectCity).Click();
        }

        public void SelectDay()
        {
            driver.ClickElement(Tomorrow);
        }
    }
}

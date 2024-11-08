using AutomationTests.Helpers;
using NUnit.Framework;
using System;
using TechTalk.SpecFlow;

namespace AutomationTests.StepDefinitions
{
    [Binding]
    public class WeatherForecastForBournemouthStepDefinitions
    {

        private readonly IWeather weather;

        public WeatherForecastForBournemouthStepDefinitions(IWeather weather)
        {
            this.weather = weather;
        }
        [Given(@"I have navigated to the BBC Weather website")]
        public void GivenIHaveNavigatedToTheBBCWeatherWebsite()
        {
           // throw new PendingStepException();
        }

        [When(@"I search for '([^']*)'")]
        public void WhenISearchFor(string city)
        {
            
            this.weather.SearchCity(city);
        }

        [Then(@"I should see the weather forecast for tomorrow")]
        public void ThenIShouldSeeTheWeatherForecastForTomorrow()
        {
            this.weather.SelectDay();
        }

        [Then(@"the high temperature should be greater than the low temperature")]
        public void ThenTheHighTemperatureShouldBeGreaterThanTheLowTemperature()
        {
            Assert.IsTrue(this.weather.GetHighTemp() > this.weather.GetLowTemp());
        }
    }
}

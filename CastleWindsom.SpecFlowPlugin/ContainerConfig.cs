using AutomationTests.Helpers;
using AutomationTests.Logging;
using AutomationTests.WebDriver.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace CastleWindsom.SpecFlowPlugin
{
    public static class ContainerConfig
    {
        private static IServiceCollection servicecollection;

        public static IServiceProvider ConfigureService()
        {
            servicecollection = new ServiceCollection();
            servicecollection.AddTransient<IWebDriverWrapper, WebDriverWrapper>();
            servicecollection.AddTransient<IWebElementWrapper, WebElementWrapper>();
            servicecollection.AddTransient<IWeather, WeatherPage>();
            return servicecollection.BuildServiceProvider();
        }
    }
}

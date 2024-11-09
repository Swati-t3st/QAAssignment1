using AutomationTests.Helpers;
using AutomationTests.Helpers.PageObjects;
using AutomationTests.Logging;
using AutomationTests.Support;
using AutomationTests.WebDriver.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace CastleWindsom.SpecFlowPlugin
{
    public static class ContainerConfig
    {
        public static IServiceCollection ConfigureService()
        {
            var services = new ServiceCollection();
            services.AddSingleton<IWebDriverWrapper, WebDriverWrapper>();
            services.AddTransient<IAccount, AccountPage>();
            services.AddTransient<ILoginPage, LoginPage>();

            services.AddSingleton(new DriverConfig
            {
                DriverType = DriverType.Chrome, // Set your desired driver type here
                DriverPath = "" // Set your driver path here
            });

            return services;
        }
    }
}

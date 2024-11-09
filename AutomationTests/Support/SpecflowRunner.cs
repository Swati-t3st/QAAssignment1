using AutomationTests.Logging;
using AutomationTests.WebDriver.Interfaces;
using AventStack.ExtentReports;
using BoDi;
using CastleWindsom.SpecFlowPlugin;
using Microsoft.Extensions.DependencyInjection;
using SolidToken.SpecFlow.DependencyInjection;
using TechTalk.SpecFlow;

namespace AutomationTests.Helpers.Runner
{
    [Binding]
    public sealed class SpecflowRunner
    {
        private readonly IObjectContainer _objectContainer;

        private readonly IWebDriverWrapper _driverWrapper;

        public SpecflowRunner(IObjectContainer objectContainer, IWebDriverWrapper driverWrapper)
        {
            _objectContainer = objectContainer;
            _driverWrapper = driverWrapper;
        }

        [BeforeTestRun]
        public static void BeforeTestRun()
        {
            ExtentReportManager.InitializeReport();
        }

        [ScenarioDependencies]
        public static IServiceCollection CreateServices()
        {
            return ContainerConfig.ConfigureService();
        }

        [BeforeFeature]
        public static void BeforeFeature(FeatureContext featureContext)
        {
            ExtentReportManager.CreateFeature(featureContext.FeatureInfo.Title);
        }


        [BeforeScenario]
        public void InitializeDependencies(ScenarioContext scenarioContext)
        {
            var serviceProvider = ContainerConfig.ConfigureService().BuildServiceProvider();
            foreach (var service in serviceProvider.GetServices<object>())
            {
                _objectContainer.RegisterInstanceAs(service);
            }

            ExtentReportManager.CreateScenario(scenarioContext.ScenarioInfo.Title);
        }

        [AfterStep]
        public void AfterStep(ScenarioContext scenarioContext)
        {
            var stepType = scenarioContext.StepContext.StepInfo.StepDefinitionType.ToString();
            var stepDescription = scenarioContext.StepContext.StepInfo.Text;

            if (scenarioContext.TestError == null)
            {
                ExtentReportManager.LogStep($"{stepType} {stepDescription}", Status.Pass);
            }
            else
            {
                ExtentReportManager.LogStep($"{stepType} {stepDescription} - {scenarioContext.TestError.Message}", Status.Fail);
            }
        }

        [AfterTestRun]
        public static void AfterTestRun()
        {
            ExtentReportManager.FlushReport();
        }
    }
}

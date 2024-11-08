using AventStack.ExtentReports;
using AventStack.ExtentReports.Gherkin.Model;
using AventStack.ExtentReports.Reporter;
using System;

public class ExtentReportManager
{
    private static ExtentReports _extent;
    private static ExtentSparkReporter _htmlReporter;
    private static ExtentTest _feature;
    private static ExtentTest _scenario;

    public static void InitializeReport()
    {
        var reportPath = $"{AppDomain.CurrentDomain.BaseDirectory}ExtentReports\\";
        _htmlReporter = new ExtentSparkReporter(reportPath);
        _htmlReporter.Config.Theme = AventStack.ExtentReports.Reporter.Config.Theme.Standard;
        _extent = new ExtentReports();
        _extent.AttachReporter(_htmlReporter);
    }

    public static void CreateFeature(string featureName)
    {
        _feature = _extent.CreateTest<Feature>(featureName);
    }

    public static void CreateScenario(string scenarioName)
    {
        _scenario = _feature.CreateNode<Scenario>(scenarioName);
    }

    public static void LogStep(string stepDescription, Status status)
    {
        _scenario.Log(status, stepDescription);
    }

    public static void FlushReport()
    {
        _extent.Flush();
    }
}

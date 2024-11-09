using AutomationTests.Helpers;
using AutomationTests.Helpers.PageObjects;
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class LoginSteps
{
    private readonly ILoginPage _loginPage;

    public LoginSteps(ILoginPage loginPage)
    {
        _loginPage = loginPage;
    }

    [Given(@"I navigate to the Magento login page")]
    public void GivenINavigateToTheMagentoLoginPage()
    {
        _loginPage.NavigateToLoginPage();
    }

    [When(@"I sign in with email ""(.*)"" and password ""(.*)""")]
    public void WhenISignInWithEmailAndPassword(string email, string password)
    {
        _loginPage.SignIn(email, password);
    }

    [Then(@"I should be logged in and see my account dashboard")]
    public void ThenIShouldBeLoggedInAndSeeMyAccountDashboard()
    {
        Assert.IsTrue(_loginPage.IsLoggedIn());
    }
}
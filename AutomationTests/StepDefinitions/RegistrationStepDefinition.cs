using AutomationTests.Helpers;
using NUnit.Framework;
using TechTalk.SpecFlow;

[Binding]
public class RegistrationSteps
{
    private readonly IAccount _accountCreationPage;

    public RegistrationSteps(IAccount accountCreationPage)
    {
        _accountCreationPage = accountCreationPage;
    }

    [Given(@"I navigate to the Magento registration page")]
    public void GivenINavigateToTheMagentoRegistrationPage()
    {
        _accountCreationPage.NavigateToRegistrationPage();
    }

    [When(@"I create an account with email ""(.*)"" and password ""(.*)""")]
    public void WhenICreateAnAccountWithEmailAndPassword(string email, string password)
    {
        _accountCreationPage.CreateAccount(email, password);
    }

    [Then(@"I should see a confirmation message indicating successful account creation")]
    public void ThenIShouldSeeAConfirmationMessageIndicatingSuccessfulAccountCreation()
    {
        // Add assertion to verify the confirmation message
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Helpers
{
    public interface IAccount
    {
        void NavigateToRegistrationPage();
        void CreateAccount(string email, string password);
       bool IsHomePageDisplayed();
    }
}

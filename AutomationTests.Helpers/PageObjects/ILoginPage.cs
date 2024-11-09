using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Helpers.PageObjects
{
    public interface ILoginPage
    {
        void NavigateToLoginPage();
        void SignIn(string email, string password);

        bool IsLoggedIn();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Helpers
{
    public interface IWeather
    {
        void SearchCity(string city);
        void SelectDay();

        int GetHighTemp();

        int GetLowTemp();
    }
}

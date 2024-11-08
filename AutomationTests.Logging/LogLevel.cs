using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Logging
{
    [Flags]
    public enum LogLevel
    {
        Fatal =1,
        Error=2,
        Warn=4,
        Info=8,
        Debug=16

    }
}

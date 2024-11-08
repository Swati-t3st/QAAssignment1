using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Logging
{
    public interface ILogger
    {
        void Write(LogLevel level, string message);

        void Write(LogLevel logLevel, string message, Exception exception);


    }
}

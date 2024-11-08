using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTests.Logging
{
    public class Logger : ILogger
    {
        public void Write(LogLevel level, string message)
        {
            Write(level, message, null);
        }

        public void Write(LogLevel logLevel, string message, Exception exception)
        {
            Write(logLevel, message, exception);
        }
    }
}

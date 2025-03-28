using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WelcomeExtended.Loggers
{
    class LoggerProvider : ILoggerProvider
    {
        ILogger ILoggerProvider.CreateLogger(string categoryName)
        {
            return new HashLogger(categoryName);
        }

        void IDisposable.Dispose()
        {
            throw new NotImplementedException();
        }
    }
}

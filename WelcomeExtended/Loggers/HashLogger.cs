using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace WelcomeExtended.Loggers
{
    class HashLogger : ILogger
    {
        private readonly ConcurrentDictionary<int, string> _logMessages;
        private readonly string _name;

        public HashLogger(string name)
        {
            _name = name;
            _logMessages = new ConcurrentDictionary<int, string>();
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
            
        }

        public bool IsEnabled(LogLevel logLevel)
        {
            return true;
        }

        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception, Func<TState, Exception?, string> formatter)
        {
            var message = formatter(state, exception);
            switch (logLevel)
            {
                case LogLevel.Critical:
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case LogLevel.Error:
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                    break;
                case LogLevel.Warning:
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }

            Console.WriteLine("--Logger--");
            var messageToBeLogged = new StringBuilder();
            messageToBeLogged.Append($"[{logLevel}]");
            messageToBeLogged.AppendFormat(" [{0}]", _name);

            Console.WriteLine(messageToBeLogged);
            Console.WriteLine($" {formatter(state, exception)}");
            Console.WriteLine("--Logger--");
            Console.ResetColor();
            _logMessages[eventId.Id] = message;
        }

        public void PrintLogs()
        {
            Console.WriteLine("--All Logs--");
            foreach (var log in _logMessages)
            {
                Console.WriteLine($"EventId {log.Key}: {log.Value}");
            }
            Console.WriteLine("--All Logs--");
        }

        public void PrintLogByEventId(int eventId)
        {
            if (_logMessages.ContainsKey(eventId))
            {
                Console.WriteLine($"EventId {eventId}: {_logMessages[eventId]}");
            }
            else
            {
                Console.WriteLine($"No log found for EventId {eventId}.");
            }
        }

        public void DeleteLogByEventId(int eventId)
        {
            if (_logMessages.ContainsKey(eventId))
            {
                _logMessages.Remove(eventId, out _);
                Console.WriteLine($"Log with EventId {eventId} deleted.");
            }
            else
            {
                Console.WriteLine($"No log found for EventId {eventId} to delete.");
            }
        }


    }
}

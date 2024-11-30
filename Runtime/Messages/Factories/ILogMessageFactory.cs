using System;
using OpenMyGame.LoggerUnity.Base;

namespace OpenMyGame.LoggerUnity.Messages.Factories
{
    internal interface ILogMessageFactory
    {
        LogMessage CreateMessage(LogLevel logLevel, string tag, Exception exception, ILogger logger);
    }
}
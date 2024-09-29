using System;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface IMessageFormat
    {
        string Render(LogMessage logMessage, Span<object> parameters);
    }
}
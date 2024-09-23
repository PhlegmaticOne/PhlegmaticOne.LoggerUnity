using System;

namespace OpenMyGame.LoggerUnity.Base
{
    public interface IMessageFormat
    {
        string Render(LogMessage logMessage, in Span<object> parameters);
    }
}
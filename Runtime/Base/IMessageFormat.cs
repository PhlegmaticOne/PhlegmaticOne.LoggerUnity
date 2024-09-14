using System;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface IMessageFormat
    {
        string Render(LogMessage logMessage, in Span<object> parameters);
    }
}
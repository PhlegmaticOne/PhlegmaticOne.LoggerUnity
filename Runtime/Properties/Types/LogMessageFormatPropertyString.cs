using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Types
{
    public class LogMessageFormatPropertyString : LogMessageFormatProperty<string>
    {
        protected override ReadOnlySpan<char> Render(string parameter, in ReadOnlySpan<char> format)
        {
            return parameter;
        }
    }
}
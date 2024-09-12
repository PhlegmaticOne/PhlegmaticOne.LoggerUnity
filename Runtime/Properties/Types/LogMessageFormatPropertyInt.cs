using System;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;

namespace OpenMyGame.LoggerUnity.Runtime.Properties.Types
{
    public class LogMessageFormatPropertyInt : LogMessageFormatProperty<int>
    {
        protected override ReadOnlySpan<char> Render(int parameter, in ReadOnlySpan<char> format)
        {
            return parameter.ToString();
        }
    }
}
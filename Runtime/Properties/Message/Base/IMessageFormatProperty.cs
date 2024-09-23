using System;

namespace OpenMyGame.LoggerUnity.Properties.Message.Base
{
    public interface IMessageFormatProperty
    {
        Type PropertyType { get; }
        ReadOnlySpan<char> Render(object parameter, in ReadOnlySpan<char> format);
    }
}
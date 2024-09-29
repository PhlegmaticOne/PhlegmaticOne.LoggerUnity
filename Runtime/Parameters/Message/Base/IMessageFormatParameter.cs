using System;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Base
{
    public interface IMessageFormatParameter
    {
        Type PropertyType { get; }
        ReadOnlySpan<char> Render(object parameter, ReadOnlySpan<char> format);
    }
}
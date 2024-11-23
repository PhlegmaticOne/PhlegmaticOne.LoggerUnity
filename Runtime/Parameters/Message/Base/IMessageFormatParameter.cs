using System;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Base
{
    public interface IMessageFormatParameter
    {
        Type PropertyType { get; }
        void Render(ref ValueStringBuilder destination, object parameter, ReadOnlySpan<char> format);
    }
}
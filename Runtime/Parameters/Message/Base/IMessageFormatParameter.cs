using System;
using Openmygame.Logger.Infrastructure.StringBuilders;

namespace Openmygame.Logger.Parameters.Message.Base
{
    public interface IMessageFormatParameter
    {
        Type PropertyType { get; }
        void Render(ref ValueStringBuilder destination, object parameter, ReadOnlySpan<char> format);
    }
}
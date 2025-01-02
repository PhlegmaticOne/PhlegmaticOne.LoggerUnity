using System;

namespace Openmygame.Logger.Parameters.Message.Serializing
{
    public interface IMessageFormatParameterSerializer
    {
        string Serialize(object value, ReadOnlySpan<char> format);
    }
}
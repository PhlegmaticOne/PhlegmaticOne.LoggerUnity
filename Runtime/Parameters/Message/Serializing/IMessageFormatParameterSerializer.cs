using System;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Serializing
{
    public interface IMessageFormatParameterSerializer
    {
        string Serialize(object value, ReadOnlySpan<char> format);
    }
}
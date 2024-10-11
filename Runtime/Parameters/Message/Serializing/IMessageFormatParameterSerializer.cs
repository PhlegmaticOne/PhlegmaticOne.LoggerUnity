using System;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Serializing
{
    /// <summary>
    /// Интерфес для сериализации параметром с префиксом @
    /// </summary>
    public interface IMessageFormatParameterSerializer
    {
        /// <summary>
        /// Сериализует параметр
        /// </summary>
        /// <param name="value">Значение параметра</param>
        /// <param name="format">Формат</param>
        string Serialize(object value, ReadOnlySpan<char> format);
    }
}
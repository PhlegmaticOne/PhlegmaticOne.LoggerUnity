using System;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Formats.Message
{
    public interface IMessageFormat
    {
        /// <summary>
        /// Рендерит сообщение
        /// </summary>
        /// <param name="messageParts">Части сообщения</param>
        /// <param name="parameters">Параметры для подстановки</param>
        ValueStringBuilder Render(MessagePart[] messageParts, Span<object> parameters);
    }
}
using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log
{
    public interface ILogFormat
    {
        /// <summary>
        /// Рендерит результирующее сообщение
        /// </summary>
        /// <param name="logMessage">Логгируемое сообщение</param>
        /// <param name="renderedMessage">Отрендеренное сообщение</param>
        /// <param name="messageParts">Части сообщения</param>
        /// <param name="parameters">Параметры для подстановки</param>
        string Render(in LogMessage logMessage, string renderedMessage, MessagePart[] messageParts, in Span<object> parameters);
    }
}
using System;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Base
{
    /// <summary>
    /// Интерфейс для параметров, которые добавляются в логгируемое сообщение
    /// </summary>
    public interface ILogFormatParameter
    {
        /// <summary>
        /// Название параметра
        /// </summary>
        string Key { get; }
        
        /// <summary>
        /// Возвращает значение параметра
        /// </summary>
        /// <param name="messagePart">Часть сообщения с названием параметра и форматом</param>
        /// <param name="message">Объект логгируемого сообщение</param>
        /// <param name="renderedMessage">Отрендеренное сообщение</param>
        ReadOnlySpan<char> GetValue(MessagePart messagePart, in LogMessage message, string renderedMessage);
    }
}
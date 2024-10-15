using System;
using System.Text;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    /// <summary>
    /// Интерфейс для обработки отрендеренных параметров для логгируемого сообщения
    /// </summary>
    public interface ILogParameterPostRenderer
    {
        /// <summary>
        /// Метод должен обработать отрендеренный параметр и затем добавить его в destination
        /// </summary>
        /// <remarks>Дефолтная реализация добавляет параметр без обработки</remarks>
        void Process(StringBuilder destination, in MessagePart messagePart, in ReadOnlySpan<char> renderedValue);
    }
}
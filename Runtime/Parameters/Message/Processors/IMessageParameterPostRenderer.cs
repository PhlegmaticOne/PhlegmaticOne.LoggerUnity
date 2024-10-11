using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    /// <summary>
    /// Интерфейс для обработки отрендеренных параметров для сообщения
    /// </summary>
    public interface IMessageParameterPostRenderer
    {
        /// <summary>
        /// Метод должен обработать отрендеренный параметр и затем добавить его в destination
        /// </summary>
        /// <remarks>Дефолтная реализация добавляет параметр без обработки</remarks>
        void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter);
    }
}
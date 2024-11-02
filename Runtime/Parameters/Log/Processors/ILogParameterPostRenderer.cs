using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    /// <summary>
    /// Интерфейс для обработки отрендеренных параметров для логгируемого сообщения
    /// </summary>
    public interface ILogParameterPostRenderer
    {
        void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue);
        void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart);
    }
}
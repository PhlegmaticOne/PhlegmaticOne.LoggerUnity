using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    /// <summary>
    /// Интерфейс для обработки отрендеренных параметров для сообщения
    /// </summary>
    public interface IMessageParameterProcessor
    {
        void Preprocess(ref ValueStringBuilder destination, object parameter);
        void Postprocess(ref ValueStringBuilder destination, object parameter);
    }
}
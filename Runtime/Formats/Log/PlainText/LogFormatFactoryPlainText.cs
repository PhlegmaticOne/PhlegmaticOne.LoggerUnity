using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    internal class LogFormatFactoryPlainText : ILogFormatFactory
    {
        private readonly MessagePart[] _messageParts;

        public LogFormatFactoryPlainText(MessagePart[] messageParts)
        {
            _messageParts = messageParts;
        }
        
        /// <summary>
        /// Создает формат для формирования результирующего сообщения в виде простого текста
        /// </summary>
        /// <param name="factoryData">Данные добавленные при конфигурации логгера</param>
        public ILogFormat CreateLogFormat(LogFormatFactoryData factoryData)
        {
            return new LogFormatPlainText(_messageParts,
                factoryData.CanAppendStacktrace, 
                factoryData.LogFormatParameters, 
                factoryData.LogParameterPostRenderer);
        }
    }
}
using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    internal class LogFormatFactoryJson : ILogFormatFactory
    {
        private readonly MessagePart[] _messageParts;

        public LogFormatFactoryJson(MessagePart[] messageParts)
        {
            _messageParts = messageParts;
        }
        
        /// <summary>
        /// Создает формат для формирования результирующего сообщения в виде JSON
        /// </summary>
        /// <param name="factoryData">Данные добавленные при конфигурации логгера</param>
        public ILogFormat CreateLogFormat(LogFormatFactoryData factoryData)
        {
            return new LogFormatJson(_messageParts,
                factoryData.CanAppendStacktrace, 
                factoryData.LogParameterPostRenderer,
                factoryData.ConfigurationParameters.PoolProvider,
                factoryData.LogFormatParameters);
        }
    }
}
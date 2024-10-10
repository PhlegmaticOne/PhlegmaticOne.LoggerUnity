using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    public class LogFormatFactoryJson : ILogFormatFactory
    {
        private readonly MessagePart[] _messageParts;

        public LogFormatFactoryJson(string format)
        {
            var parser = new MessageFormatParser();
            _messageParts = parser.Parse(format);
        }
        
        public ILogFormat CreateLogFormat(MessageFormatsFactoryData factoryData)
        {
            return new LogFormatJson(_messageParts,
                factoryData.AppendStackTraceToRenderingMessage, 
                factoryData.LogParameterPostRenderer,
                factoryData.ConfigurationParameters.PoolProvider,
                factoryData.LogFormatParameters);
        }
    }
}
using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    public class LogFormatFactoryPlainText : ILogFormatFactory
    {
        private readonly MessagePart[] _messageParts;

        public LogFormatFactoryPlainText(string format)
        {
            var parser = new MessageFormatParser();
            _messageParts = parser.Parse(format);
        }
        
        public ILogFormat CreateLogFormat(MessageFormatsFactoryData factoryData)
        {
            return new LogFormatPlainText(_messageParts,
                factoryData.AppendStackTraceToRenderingMessage, 
                factoryData.LogFormatParameters, 
                factoryData.LogParameterPostRenderer, 
                factoryData.ConfigurationParameters.PoolProvider);
        }
    }
}
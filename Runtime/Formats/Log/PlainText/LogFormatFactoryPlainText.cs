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
        
        public ILogFormat CreateLogFormat(LogFormatFactoryData factoryData)
        {
            return new LogFormatPlainText(_messageParts,
                factoryData.LogFormatParameters, 
                factoryData.LogParameterProcessor);
        }
    }
}
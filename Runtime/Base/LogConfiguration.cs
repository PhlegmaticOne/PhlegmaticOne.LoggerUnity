using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Factories;
using OpenMyGame.LoggerUnity.Properties.Log;
using OpenMyGame.LoggerUnity.Properties.Log.Base;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogConfiguration
    {
        private readonly List<ILogFormatParameter> _logFormatParameters;
        
        protected LogConfiguration()
        {
            MinimumLogLevel = LogLevel.Debug;
            LogFormat = "{Message}";
            IsEnabled = true;
            
            _logFormatParameters = new List<ILogFormatParameter>
            {
                new LogFormatParameterException(),
                new LogFormatParameterStacktrace(),
                new LogFormatParameterTime(),
                new LogFormatParameterLogLevel(),
                new LogFormatParameterUnityTime(),
                new LogFormatParameterNewLine(),
                new LogFormatParameterMessage(),
                new LogFormatParameterThreadId(),
                new LogFormatParameterTimeUtc()
            };
        }

        public bool IsEnabled { get; set; }
        public string LogFormat { set; get; }
        public LogLevel MinimumLogLevel { get; set; }

        public LogConfiguration AddLogFormatParameter(ILogFormatParameter formatParameter)
        {
            if (formatParameter is not null)
            {
                _logFormatParameters.Add(formatParameter);
            }
            
            return this;
        }

        internal IMessageFormat CreateMessageFormat()
        {
            return GetFormatParser().Parse(LogFormat);
        }

        private IMessageFormatParser GetFormatParser()
        {
            var factory = new MessageFormatFactoryDestination(_logFormatParameters);
            return new MessageFormatParser(factory);
        }
    }
}
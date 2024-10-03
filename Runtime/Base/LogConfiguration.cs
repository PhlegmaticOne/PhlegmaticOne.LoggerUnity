using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Base;
using OpenMyGame.LoggerUnity.Parsing.Factories;

namespace OpenMyGame.LoggerUnity.Base
{
    public abstract class LogConfiguration
    {
        private readonly List<ILogFormatParameter> _logFormatParameters;
        
        protected LogConfiguration()
        {
            MinimumLogLevel = LoggerStaticData.MinimumLogLevel;
            LogFormat = LoggerStaticData.LogFormat;
            IsEnabled = LoggerStaticData.IsEnabled;
            _logFormatParameters = LoggerStaticData.LogFormatParameters;
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
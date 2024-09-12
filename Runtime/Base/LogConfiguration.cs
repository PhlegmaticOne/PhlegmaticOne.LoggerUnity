using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public abstract class LogConfiguration
    {
        private readonly List<ILogFormatProperty> _formatProperties;
        
        protected LogConfiguration()
        {
            MinimumLogLevel = LogLevel.Debug;
            LogFormat = "{Message}";
            IsEnabled = true;
            
            _formatProperties = new List<ILogFormatProperty>
            {
                new LogFormatPropertyException(),
                new LogFormatPropertyStacktrace(),
                new LogFormatPropertyTime(),
                new LogFormatPropertyLogLevel(),
                new LogFormatPropertyUnityTime(),
                new LogFormatPropertyNewLine(),
                new LogFormatPropertyMessage(),
                new LogFormatPropertyThreadId()
            };

            FormatParser = new MessageFormatParser();
        }

        public bool IsEnabled { get; set; }
        public string LogFormat { set; get; }
        public LogLevel MinimumLogLevel { get; set; }
        public IMessageFormatParser FormatParser { get; }

        public LogConfiguration AddLogFormatProperty(ILogFormatProperty formatProperty)
        {
            _formatProperties.Add(formatProperty);
            return this;
        }

        public MessageFormat CreateMessageFormat()
        {
            return GetFormatParser().Parse(LogFormat, GetMessagePartRenderer());
        }

        protected virtual IMessageFormatParser GetFormatParser()
        {
            return new MessageFormatParser();
        }

        protected virtual ILogMessagePartRenderer GetMessagePartRenderer()
        {
            return new LogMessagePartRendererFormatProperties(_formatProperties);
        }
    }
}
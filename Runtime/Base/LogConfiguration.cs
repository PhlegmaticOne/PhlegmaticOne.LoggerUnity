using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log.Renderer;

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
        }

        public bool IsEnabled { get; set; }
        public string LogFormat { set; get; }
        public LogLevel MinimumLogLevel { get; set; }

        public LogConfiguration AddLogFormatProperty(ILogFormatProperty formatProperty)
        {
            if (formatProperty is not null)
            {
                _formatProperties.Add(formatProperty);
            }
            
            return this;
        }

        public IMessageFormat CreateMessageFormat()
        {
            return GetFormatParser().Parse(LogFormat, GetMessagePartRenderer());
        }

        protected virtual IMessageFormatParser GetFormatParser()
        {
            return new MessageFormatParser();
        }

        protected virtual ILogMessagePartRenderer GetMessagePartRenderer()
        {
            return new LogMessagePartRendererLogFormat(_formatProperties);
        }
    }
}
using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Tagging;
using UnityEngine.Pool;

namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public class LogMessage
    {
        private Dictionary<string, object> _contextValues;
        public static LogMessage Empty => new(LogLevel.Debug, null);
        
        public LogMessage(LogLevel logLevel, IMessageFormat format, Exception exception = null)
        {
            LogLevel = logLevel;
            Format = format;
            Exception = exception;
        }
        
        public LogLevel LogLevel { get; }
        public IMessageFormat Format { get; }
        public Exception Exception { get; }
        public LogTag Tag { get; private set; }

        public string Render(in Span<object> parameters)
        {
            return Format?.Render(this, parameters) ?? string.Empty;
        }

        public void SetTag(in LogTag logTag)
        {
            Tag = logTag;
        }

        public void Dispose()
        {
            if (_contextValues is null)
            {
                return;
            }
            
            DictionaryPool<string, object>.Release(_contextValues);
            _contextValues = null;
        }
    }
}
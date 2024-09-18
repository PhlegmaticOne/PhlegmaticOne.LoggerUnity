using System;
using System.Collections.Generic;
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

        public string Render(in Span<object> parameters)
        {
            return Format?.Render(this, parameters) ?? string.Empty;
        }

        public void AddContextProperty(string propertyKey, object propertyValue)
        {
            _contextValues ??= DictionaryPool<string, object>.Get();
            _contextValues.Add(propertyKey, propertyValue);
        }

        public bool TryGetContextProperty<T>(string propertyKey, out T propertyValue)
        {
            if (_contextValues.TryGetValue(propertyKey, out var property))
            {
                propertyValue = (T)property;
                return true;
            }

            propertyValue = default;
            return false;
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
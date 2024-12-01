using System;
using System.Buffers;
using System.Diagnostics;
using System.Threading;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.InlineArrays;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public struct LogMessage
    {
        private static int CurrentId = -1;
        
        private readonly ILogger _logger;
        private readonly LogTagFormat _logTagFormat;

        public LogMessage(LogLevel logLevel, ILogger logger, LogTagFormat logTagFormat, string tag = null, Exception exception = null)
        {
            _logger = logger;
            _logTagFormat = logTagFormat;
            Id = Interlocked.Increment(ref CurrentId);
            LogLevel = logLevel;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
            SetTag(tag);
            SetException(exception);
        }
        
        public int Id { get; }
        public LogLevel LogLevel { get; }
        public Exception Exception { get; private set; }
        public LogTag Tag { get; private set; }
        public string Format { get; private set; }

        public void SetTag(string tag)
        {
            if (!string.IsNullOrEmpty(tag))
            {
                Tag = new LogTag(tag, _logTagFormat);
            }
        }

        public void SetException(Exception exception)
        {
            if (exception is not null)
            {
                Exception = exception;
            }
        }

        public void SetFormat(string format)
        {
            Format = format;
        }

        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log(string message)
        {
            if (!CanLogMessage(message))
            {
                return;
            }

            if (!Tag.HasValue())
            {
                SetFormat(LoggerConfigurationData.MessageFormat);
                var propertiesInlineArray = new PropertyInlineArray1();
                var parameters = propertiesInlineArray.AsSpan();
                parameters[0] = message;
                _logger.LogMessage(this, parameters);
            }
            else
            {
                SetFormat(AddTagToFormat(LoggerConfigurationData.MessageFormat));
                var propertiesInlineArray = new PropertyInlineArray2();
                var parameters = propertiesInlineArray.AsSpan();
                parameters[0] = Tag;
                parameters[1] = message;
                _logger.LogMessage(this, parameters);
            }
        }
        
        [Conditional(LoggerConfigurationData.ConditionalName)]
        public void Log(string format, params object[] parameters)
        {
            if (!CanLogMessage(format))
            {
                return;
            }
            
            if (!Tag.HasValue())
            {
                SetFormat(format);
                _logger.LogMessage(this, parameters);
            }
            else
            {
                SetFormat(AddTagToFormat(format));
                var parametersAppend = parameters.PrependValue(Tag);
                _logger.LogMessage(this, parametersAppend);
                ArrayPool<object>.Shared.Return(parametersAppend, true);
            }
        }
        
        public override string ToString()
        {
            return Format;
        }
        
        private bool CanLogMessage(string format)
        {
            return _logger is not null && _logger.IsEnabled && !string.IsNullOrEmpty(format);
        }
        
        private string AddTagToFormat(string format)
        {
            return _logTagFormat is null ? format : _logTagFormat.AddTagToFormat(format);
        }
    }
}
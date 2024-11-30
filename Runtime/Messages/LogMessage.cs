using System;
using System.Buffers;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Infrastructure.Extensions;
using OpenMyGame.LoggerUnity.Infrastructure.InlineArrays;
using OpenMyGame.LoggerUnity.Messages.Tagging;

namespace OpenMyGame.LoggerUnity.Messages
{
    public struct LogMessage
    {
        private const string MessageFormat = "{Message}";
        
        private readonly ILogger _logger;

        public LogMessage(int id, LogLevel logLevel, ILogger logger)
        {
            _logger = logger;
            Id = id;
            LogLevel = logLevel;
            Exception = null;
            Format = null;
            Tag = LogTag.Empty;
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
                Tag = new LogTag(tag);
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
                SetFormat(MessageFormat);
                var propertiesInlineArray = new PropertyInlineArray1();
                var parameters = propertiesInlineArray.AsSpan();
                parameters[0] = message;
                _logger.LogMessage(this, parameters);
            }
            else
            {
                SetFormat(AddTagToFormat(MessageFormat));
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
            return _logger.IsEnabled && !string.IsNullOrEmpty(format);
        }
        
        private static string AddTagToFormat(string format)
        {
            return LogTag.Format.AddTagToFormat(format);
        }
    }
}
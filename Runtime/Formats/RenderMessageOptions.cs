using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Formats.Log.Json;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;

namespace OpenMyGame.LoggerUnity.Formats
{
    public class RenderMessageOptions
    {
        private readonly LogConfiguration _logConfiguration;

        public RenderMessageOptions(LogConfiguration logConfiguration)
        {
            _logConfiguration = logConfiguration;
            PlainText(LoggerStaticData.LogFormat);
        }
        
        public void PlainText(string format)
        {
            ValidateFormat(format);
            _logConfiguration.SetFormatsFactory(new LogFormatFactoryPlainText(format));
        }

        public void Json(string format)
        {
            ValidateFormat(format);
            _logConfiguration.SetFormatsFactory(new LogFormatFactoryJson(format));
        }

        public void FromFactory(ILogFormatFactory logFormatFactory)
        {
            if (logFormatFactory is not null)
            {
                _logConfiguration.SetFormatsFactory(logFormatFactory);
            }
        }
        
        private static void ValidateFormat(string format)
        {
            if (string.IsNullOrEmpty(format))
            {
                throw new ArgumentException("Log format cannot be an empty string", nameof(format));
            }
        }
    }
}
using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;

namespace OpenMyGame.LoggerUnity.Base
{
    internal static class LoggerStaticData
    {
        public const string ConditionalName = "UNITY_LOGGING_ENABLED";
        public const LogLevel MinimumLogLevel = LogLevel.Debug;
        public const string LogFormat = "{Message}";
        public const string TagFormat = "#{Tag}#";
        public const bool IsEnabled = true;
        public const char SerializeParameterPrefix = '@';
        public const bool IsCacheFormats = true;
        public const string DefaultTagValue = "Unity";
        public const string ExceptionFormat = "{Exception}";

        public static List<ILogFormatParameter> LogFormatParameters => new()
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

        public static Dictionary<Type, IMessageFormatParameter> MessageFormatParameters
        {
            get
            {
                var formatParameters = new Dictionary<Type, IMessageFormatParameter>();
                AddMessageFormatProperty(formatParameters, new MessageFormatParameterString());
                AddMessageFormatProperty(formatParameters, new MessageFormatParameterDateTime());
                AddMessageFormatProperty(formatParameters, new MessageFormatParameterTimeSpan());
                AddMessageFormatProperty(formatParameters, new MessageFormatParameterGuid());
                AddMessageFormatProperty(formatParameters, new MessageFormatParameterTag());
                return formatParameters;
            }
        }

        private static void AddMessageFormatProperty(
            IDictionary<Type, IMessageFormatParameter> formatParameters, 
            IMessageFormatParameter formatParameter)
        {
            formatParameters[formatParameter.PropertyType] = formatParameter;
        }
    }
}
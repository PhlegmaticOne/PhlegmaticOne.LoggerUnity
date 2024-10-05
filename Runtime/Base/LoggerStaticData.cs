using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;

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
        public const string MessageKey = "Message";

        public static ILogParameterPostRenderProcessor LogParameterPostRenderProcessor =>
            new LogParameterPostRenderProcessor();

        public static IMessageParameterPostRenderProcessor MessageParameterPostRenderProcessor =>
            new MessageParameterPostRenderProcessor();

        public static Dictionary<string, ILogFormatParameter> LogFormatParameters
        {
            get
            {
                var result = new Dictionary<string, ILogFormatParameter>();
                AddLogFormatProperty(result, new LogFormatParameterException());
                AddLogFormatProperty(result, new LogFormatParameterStacktrace());
                AddLogFormatProperty(result, new LogFormatParameterTime());
                AddLogFormatProperty(result, new LogFormatParameterLogLevel());
                AddLogFormatProperty(result, new LogFormatParameterUnityTime());
                AddLogFormatProperty(result, new LogFormatParameterNewLine());
                AddLogFormatProperty(result, new LogFormatParameterMessage());
                AddLogFormatProperty(result, new LogFormatParameterThreadId());
                AddLogFormatProperty(result, new LogFormatParameterTimeUtc());
                return result;
            }
        }

        public static Dictionary<Type, IMessageFormatParameter> MessageFormatParameters
        {
            get
            {
                var result = new Dictionary<Type, IMessageFormatParameter>();
                AddMessageFormatProperty(result, new MessageFormatParameterString());
                AddMessageFormatProperty(result, new MessageFormatParameterDateTime());
                AddMessageFormatProperty(result, new MessageFormatParameterTimeSpan());
                AddMessageFormatProperty(result, new MessageFormatParameterGuid());
                AddMessageFormatProperty(result, new MessageFormatParameterTag());
                return result;
            }
        }

        private static void AddLogFormatProperty(
            IDictionary<string, ILogFormatParameter> formatParameters, 
            ILogFormatParameter formatParameter)
        {
            formatParameters[formatParameter.Key] = formatParameter;
            
        }
        private static void AddMessageFormatProperty(
            IDictionary<Type, IMessageFormatParameter> formatParameters, 
            IMessageFormatParameter formatParameter)
        {
            formatParameters[formatParameter.PropertyType] = formatParameter;
        }
    }
}
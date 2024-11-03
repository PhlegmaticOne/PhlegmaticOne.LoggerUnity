using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Exceptions;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parameters.Log.Base;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Base
{
    internal static class LoggerStaticData
    {
        public static readonly Color DefaultLogTextColor = Color.white;
        public const string ConditionalName = "UNITY_LOGGING_ENABLED";
        public const LogLevel MinimumLogLevel = LogLevel.Debug;
        public const string ExceptionPlaceholderFormat = "{Placeholder}";
        public static readonly LogExceptionPlaceholder ExceptionPlaceholder = new("Exception occurred!");
        public const char SerializeParameterPrefix = '@';
        public const string LogFormat = "{Message}{NewLine}{Exception}";
        public const string TagFormat = "#{Tag}#";
        public const string MessageParameterKey = "Message";
        
        public const int StacktraceDepth = 4;
        public const int StacktraceBufferSize = 18000;
        public const byte NewLineByte = 10;

        public const bool IsExtractStacktrace = false;
        public const bool IsEnabled = true;
        
        public static IMessageFormatParameterSerializer MessageFormatParameterSerializer =>
            new MessageFormatParameterSerializer();

        public static ILogParameterPostRenderer LogParameterPostRenderer =>
            new LogParameterPostRenderer();

        public static IMessageParameterPostRenderer MessageParameterPostRenderer =>
            new MessageParameterPostRenderer();

        public static Dictionary<string, ILogFormatParameter> LogFormatParameters
        {
            get
            {
                var result = new Dictionary<string, ILogFormatParameter>();
                AddLogFormatProperty(result, new LogFormatParameterException());
                AddLogFormatProperty(result, new LogFormatParameterTime());
                AddLogFormatProperty(result, new LogFormatParameterLogLevel());
                AddLogFormatProperty(result, new LogFormatParameterUnityTime());
                AddLogFormatProperty(result, new LogFormatParameterNewLine());
                AddLogFormatProperty(result, new LogFormatParameterThreadId());
                AddLogFormatProperty(result, new LogFormatParameterTimeUtc());
                AddLogFormatProperty(result, new LogFormatParameterMessageId());
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
                AddMessageFormatProperty(result, new MessageFormatParameterExceptionPlaceholder());
                AddMessageFormatProperty(result, new MessageFormatParameterBool());
                AddMessageFormatProperty(result, new MessageFormatParameterByte());
                AddMessageFormatProperty(result, new MessageFormatParameterChar());
                AddMessageFormatProperty(result, new MessageFormatParameterDecimal());
                AddMessageFormatProperty(result, new MessageFormatParameterDouble());
                AddMessageFormatProperty(result, new MessageFormatParameterFloat());
                AddMessageFormatProperty(result, new MessageFormatParameterInt());
                AddMessageFormatProperty(result, new MessageFormatParameterLong());
                AddMessageFormatProperty(result, new MessageFormatParameterSByte());
                AddMessageFormatProperty(result, new MessageFormatParameterShort());
                AddMessageFormatProperty(result, new MessageFormatParameterTag());
                AddMessageFormatProperty(result, new MessageFormatParameterUInt());
                AddMessageFormatProperty(result, new MessageFormatParameterULong());
                AddMessageFormatProperty(result, new MessageFormatParameterUShort());
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
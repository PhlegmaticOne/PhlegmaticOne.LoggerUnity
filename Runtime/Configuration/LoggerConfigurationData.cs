using System;
using System.Collections.Generic;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Exceptions;
using Openmygame.Logger.Parameters.Log;
using Openmygame.Logger.Parameters.Log.Base;
using Openmygame.Logger.Parameters.Log.Processors;
using Openmygame.Logger.Parameters.Message;
using Openmygame.Logger.Parameters.Message.Base;
using Openmygame.Logger.Parameters.Message.Processors;
using Openmygame.Logger.Parameters.Message.Serializing;
using UnityEngine;

namespace Openmygame.Logger.Configuration
{
    public static class LoggerConfigurationData
    {
        public const string ConditionalName = "ENABLE_LOGGING";
        
        internal static readonly Color DefaultLogTextColor = Color.white;
        internal const LogLevel MinimumLogLevel = LogLevel.Debug;
        internal const string ExceptionPlaceholderFormat = "{Placeholder}";
        internal static readonly LogExceptionPlaceholder ExceptionPlaceholder = new("Exception occurred!");
        internal const char SerializeParameterPrefix = '@';
        internal const string LogFormat = "{Message}{NewLine}{Exception}";
        internal const string MessageFormat = "{Message}";
        internal const string TagFormat = "#{Tag}#";
        internal const string MessageParameterKey = "Message";
        internal const string FormatParameterName = "format";
        
        internal const int StacktraceDepth = 2;
        internal const int StacktraceBufferSize = 8192;

        internal const bool IsExtractStacktrace = false;
        internal const bool IsEnabled = true;
        
        internal static IMessageFormatParameterSerializer MessageFormatParameterSerializer =>
            new MessageFormatParameterSerializer();

        internal static ILogParameterProcessor LogParameterProcessor =>
            new LogParameterProcessor();

        internal static IMessageParameterProcessor MessageParameterProcessor =>
            new MessageParameterProcessor();

        internal static Dictionary<string, ILogFormatParameter> LogFormatParameters
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

        internal static Dictionary<Type, IMessageFormatParameter> MessageFormatParameters
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
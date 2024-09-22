using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Runtime.Attributes;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Parsing.Infrastructure;
using OpenMyGame.LoggerUnity.Runtime.Tagging;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public static class Log
    {
        private static ILogger LoggerPrivate;

        public static ILogger Logger
        {
            get => LoggerPrivate;
            set
            {
                if (LoggerPrivate is not null)
                {
                    LoggerPrivate.MessageLogged -= OnMessageLogged;
                    LoggerPrivate.Dispose();
                }

                LoggerPrivate = value;
                LoggerPrivate.MessageLogged += OnMessageLogged;
            }
        }

        private static void OnMessageLogged(LogMessage obj)
        {
            MessageLogged?.Invoke(obj);
        }

        public static event Action<LogMessage> MessageLogged;
        
        public static bool IsEnabled()
        {
            return Logger is not null && Logger.IsEnabled;
        }
        
        public static LogWithTag WithTag(string tag)
        {
            return Logger.CreateLogWithTag(tag);
        }

        public static void SetDestinationEnabled(string destinationName, bool isEnabled)
        {
            Logger.SetDestinationEnabled(destinationName, isEnabled);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Exception(Exception exception)
        {
            if (!IsEnabled())
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Fatal, "{Exception}", Span<object>.Empty, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug(string format, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Debug, format, Span<object>.Empty, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T>(string format, T parameter1, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray2();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray3();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray4();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            properties[3] = parameter4;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug(string format, Exception exception = null, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Debug, format, parameters, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning(string format, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Warning, format, Span<object>.Empty, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T>(string format, T parameter1, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Warning, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray2();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            Logger.LogMessage(LogLevel.Warning, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray3();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            Logger.LogMessage(LogLevel.Warning, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray4();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            properties[3] = parameter4;
            Logger.LogMessage(LogLevel.Warning, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning(string format, Exception exception = null, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Warning, format, parameters, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error(string format, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Error, format, Span<object>.Empty, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T>(string format, T parameter1, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray2();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            Logger.LogMessage(LogLevel.Error, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray3();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            Logger.LogMessage(LogLevel.Error, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray4();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            properties[3] = parameter4;
            Logger.LogMessage(LogLevel.Error, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error(string format, Exception exception = null, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Warning, format, parameters, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal(string format, Exception exception = null)
        {
            Logger.LogMessage(LogLevel.Fatal, format, Span<object>.Empty, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T>(string format, T parameter1, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Debug, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray2();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            Logger.LogMessage(LogLevel.Fatal, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray3();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            Logger.LogMessage(LogLevel.Fatal, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray4();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            properties[1] = parameter2;
            properties[2] = parameter3;
            properties[3] = parameter4;
            Logger.LogMessage(LogLevel.Fatal, format, properties, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal(string format, Exception exception = null, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Fatal, format, parameters, exception);
        }
    }
}
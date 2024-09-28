using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parsing.Infrastructure;
using OpenMyGame.LoggerUnity.Tagging;

namespace OpenMyGame.LoggerUnity
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
        public static void Debug(string format)
        {
            Debug(null as Exception, format);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug(Exception exception, string format)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Logger.LogMessage(LogLevel.Debug, format, Span<object>.Empty, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T>(string format, T parameter1)
        {
            Debug(null as Exception, format, parameter1);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T>(Exception exception, string format, T parameter1)
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
        public static void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            Debug(null as Exception, format, parameter1, parameter2);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2>(Exception exception, string format, T1 parameter1, T2 parameter2)
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
        public static void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Debug(null as Exception, format, parameter1, parameter2, parameter3);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2, T3>(Exception exception, string format, T1 parameter1, T2 parameter2, T3 parameter3)
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
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Debug(null as Exception, format, parameter1, parameter2, parameter3, parameter4);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug<T1, T2, T3, T4>(Exception exception, string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
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
        public static void Debug(string format, params object[] parameters)
        {
            Debug(null as Exception, format, parameters);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Debug(Exception exception, string format, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Debug, format, parameters, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning(string format)
        {
            Warning(null as Exception, format);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning(Exception exception, string format)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Warning, format, Span<object>.Empty, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T>(string format, T parameter1)
        {
            Warning(null as Exception, format, parameter1);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T>(Exception exception, string format, T parameter1)
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
        public static void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            Warning(null as Exception, format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2>(Exception exception, string format, T1 parameter1, T2 parameter2)
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
        public static void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Warning(null as Exception, format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2, T3>(Exception exception, string format, T1 parameter1, T2 parameter2, T3 parameter3)
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
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Warning(null as Exception, format, parameter1, parameter2, parameter3, parameter4);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning<T1, T2, T3, T4>(Exception exception, string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
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
        public static void Warning(string format, params object[] parameters)
        {
            Warning(null as Exception, format, parameters);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Warning(Exception exception, string format, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Warning, format, parameters, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error(string format)
        {
            Error(null as Exception, format);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error(Exception exception, string format)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Error, format, Span<object>.Empty, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T>(string format, T parameter1)
        {
            Error(null as Exception, format, parameter1);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T>(Exception exception, string format, T parameter1)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Error, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            Error(null as Exception, format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2>(Exception exception, string format, T1 parameter1, T2 parameter2)
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
        public static void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Error(null as Exception, format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2, T3>(Exception exception, string format, T1 parameter1, T2 parameter2, T3 parameter3)
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
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Error(null as Exception, format, parameter1, parameter2, parameter3, parameter4);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error<T1, T2, T3, T4>(Exception exception, string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
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
        public static void Error(string format, params object[] parameters)
        {
            Error(null as Exception, format, parameters);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Error(Exception exception, string format, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Error, format, parameters, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal(string format)
        {
            Fatal(null as Exception, format);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal(Exception exception, string format)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Fatal, format, Span<object>.Empty, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T>(string format, T parameter1)
        {
            Fatal(null as Exception, format, parameter1);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T>(Exception exception, string format, T parameter1)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            var propertiesInlineArray = new PropertyInlineArray1();
            var properties = propertiesInlineArray.AsSpan();
            properties[0] = parameter1;
            Logger.LogMessage(LogLevel.Fatal, format, properties, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2)
        {
            Fatal(null as Exception, format, parameter1, parameter2);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2>(Exception exception, string format, T1 parameter1, T2 parameter2)
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
        public static void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3)
        {
            Fatal(null as Exception, format, parameter1, parameter2, parameter3);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2, T3>(Exception exception, string format, T1 parameter1, T2 parameter2, T3 parameter3)
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
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
        {
            Fatal(null as Exception, format, parameter1, parameter2, parameter3, parameter4);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal<T1, T2, T3, T4>(Exception exception, string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4)
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
        public static void Fatal(string format, params object[] parameters)
        {
            Fatal(null as Exception, format, parameters);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public static void Fatal(Exception exception, string format, params object[] parameters)
        {
            if (!IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }

            Logger.LogMessage(LogLevel.Fatal, format, parameters, exception);
        }

        private static void OnMessageLogged(LogMessage obj)
        {
            MessageLogged?.Invoke(obj);
        }
    }
}
using System;
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Runtime.Attributes;

namespace OpenMyGame.LoggerUnity.Runtime.Tagging
{
    public readonly struct LogWithTag
    {
        public const string ParameterName = "Tag";
        
        private readonly string _tag;
        private readonly string _tagFormat;

        public LogWithTag(string tag, string tagFormat)
        {
            _tag = tag;
            _tagFormat = tagFormat;
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, parameter1, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, parameter4, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3, T4, T5>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3, T4, T5, T6>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3, T4, T5, T6, T7>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, T7 parameter7, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), AddTagToParameters(_tag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, parameter4, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3, T4, T5>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3, T4, T5, T6>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3, T4, T5, T6, T7>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, T7 parameter7, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), AddTagToParameters(_tag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, parameter4, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3, T4, T5>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3, T4, T5, T6>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3, T4, T5, T6, T7>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, T7 parameter7, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), AddTagToParameters(_tag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3, T4>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, parameter1, parameter2, parameter3, parameter4, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3, T4, T5>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3, T4, T5, T6>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3, T4, T5, T6, T7>(string format, 
            T1 parameter1, T2 parameter2, T3 parameter3, T4 parameter4, 
            T5 parameter5, T6 parameter6, T7 parameter7, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _tag, 
                parameter1, parameter2, parameter3, parameter4, parameter5, parameter6, parameter7, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), AddTagToParameters(_tag, parameters), exception);
        }

        private string AddTagToFormat(string format)
        {
            return string.Concat(_tagFormat, format);
        }

        private static object[] AddTagToParameters(string tag, params object[] parameters)
        {
            var result = new object[parameters.Length + 1];
            result[0] = tag;
            parameters.CopyTo(result, 1);
            return result;
        }
    }
}
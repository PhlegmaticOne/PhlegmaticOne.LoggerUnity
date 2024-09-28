using System;
using System.Diagnostics;
using System.Text;
using OpenMyGame.LoggerUnity.Attributes;
using OpenMyGame.LoggerUnity.Parameters.Message;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tagging
{
    public readonly struct LogWithTag
    {
        public const string PropertyKey = "Tag";
        
        private readonly LogTag _logTag;
        private readonly string _tagFormat;
        private readonly bool _isColorize;

        public LogWithTag(string tag, string tagFormat, bool isColorize)
        {
            _logTag = new LogTag(tag);
            _tagFormat = tagFormat;
            _isColorize = isColorize;
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _logTag, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _logTag, parameter1, exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _logTag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), _logTag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Debug(AddTagToFormat(format), AddTagToParameters(_logTag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _logTag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _logTag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _logTag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), _logTag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Warning(AddTagToFormat(format), AddTagToParameters(_logTag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _logTag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _logTag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _logTag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), _logTag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Error(AddTagToFormat(format), AddTagToParameters(_logTag, parameters), exception);
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal(string format, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _logTag, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T>(string format, T parameter1, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _logTag, parameter1, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2>(string format, T1 parameter1, T2 parameter2, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _logTag, parameter1, parameter2, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal<T1, T2, T3>(string format, T1 parameter1, T2 parameter2, T3 parameter3, Exception exception = null)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), _logTag, parameter1, parameter2, parameter3, exception);
        }

        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal(string format, Exception exception = null, params object[] parameters)
        {
            if (!Log.IsEnabled() || string.IsNullOrEmpty(format))
            {
                return;
            }
            
            Log.Fatal(AddTagToFormat(format), AddTagToParameters(_logTag, parameters), exception);
        }

        internal string Format(in Color color)
        {
            if (!_isColorize)
            {
                var formatString = _tagFormat.Replace(PropertyKey, "0");
                return string.Format(formatString, _logTag.Tag);
            }
            
            var split = _tagFormat.Split('{', '}');
            var result = new StringBuilder();

            result.Append(split[0]);
            result.Append(MessageFormatParameterTag.ColorizeTag(_logTag.Tag, color));
            result.Append(split[2]);
            
            return result.ToString();
        }

        private string AddTagToFormat(string format)
        {
            return $"{_tagFormat} {format}";
        }

        private static object[] AddTagToParameters(LogTag logTag, params object[] parameters)
        {
            var result = new object[parameters.Length + 1];
            result[0] = logTag;
            parameters.CopyTo(result, 1);
            return result;
        }
    }
}
using System.Diagnostics;
using OpenMyGame.LoggerUnity.Runtime.Attributes;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public readonly struct LogWithTag
    {
        private readonly string _tag;

        public LogWithTag(string tag)
        {
            _tag = tag;
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Debug(string format, params object[] parameters)
        {
            Log.Debug(AddTagToFormat(format), AddTagToParameters(_tag, parameters));
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Warning(string format, params object[] parameters)
        {
            Log.Warning(AddTagToFormat(format), AddTagToParameters(_tag, parameters));
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Error(string format, params object[] parameters)
        {
            Log.Error(AddTagToFormat(format), AddTagToParameters(_tag, parameters));
        }
        
        [MessageTemplateFormatMethod("format")]
        [Conditional("UNITY_LOGGING_ENABLED")]
        public void Fatal(string format, params object[] parameters)
        {
            Log.Fatal(AddTagToFormat(format), AddTagToParameters(_tag, parameters));
        }
        
        private static object[] AddTagToParameters(string tag, params object[] parameters)
        {
            var result = new object[parameters.Length + 1];
            result[0] = tag;
            parameters.CopyTo(result, 1);
            return result;
        }

        private static string AddTagToFormat(string format)
        {
            return string.Concat("#{Tag}# ", format);
        }
    }
}
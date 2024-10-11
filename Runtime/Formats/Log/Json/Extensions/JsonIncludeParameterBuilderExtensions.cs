using OpenMyGame.LoggerUnity.Parameters.Log;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    public static class JsonIncludeParameterBuilderExtensions
    {
        public static void ThreadId(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterThreadId.KeyParameter);
        }

        public static void LogLevel(this JsonIncludeParametersBuilder parametersBuilder, string format = null)
        {
            parametersBuilder.Parameter(
                CreateParameterValue(LogFormatParameterLogLevel.KeyParameter, format));
        }

        public static void MessageId(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterMessageId.KeyParameter);
        }

        public static void Time(this JsonIncludeParametersBuilder parametersBuilder, string format = null)
        {
            parametersBuilder.Parameter(
                CreateParameterValue(LogFormatParameterTime.KeyParameter, format));
        }
        
        public static void TimeUtc(this JsonIncludeParametersBuilder parametersBuilder, string format = null)
        {
            parametersBuilder.Parameter(
                CreateParameterValue(LogFormatParameterTimeUtc.KeyParameter, format));
        }

        public static void UnityTime(this JsonIncludeParametersBuilder parametersBuilder, string format = null)
        {
            parametersBuilder.Parameter(
                CreateParameterValue(LogFormatParameterUnityTime.KeyParameter, format));
        }

        private static string CreateParameterValue(string parameterKey, string format)
        {
            return string.IsNullOrEmpty(format) ? parameterKey : string.Concat(parameterKey, ":", format);
        }
    }
}
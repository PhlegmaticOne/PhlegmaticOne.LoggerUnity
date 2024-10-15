using OpenMyGame.LoggerUnity.Parameters.Log;

namespace OpenMyGame.LoggerUnity.Formats.Log.Json
{
    public static class JsonIncludeParameterBuilderExtensions
    {
        public static void ThreadId(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterThreadId.KeyParameter);
        }

        public static void LogLevel(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterLogLevel.KeyParameter);
        }

        public static void MessageId(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterMessageId.KeyParameter);
        }

        public static void Time(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterTime.KeyParameter);
        }
        
        public static void TimeUtc(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterTimeUtc.KeyParameter);
        }

        public static void UnityTime(this JsonIncludeParametersBuilder parametersBuilder)
        {
            parametersBuilder.Parameter(LogFormatParameterUnityTime.KeyParameter);
        }
    }
}
using Openmygame.Logger.Base;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
#if !UNITY_EDITOR && UNITY_IOS
using System.Runtime.InteropServices;
#endif

namespace Openmygame.Logger.Destinations.IOS
{
    public class IOSLogDestination : LogDestination<IOSLogConfiguration>
    {
#if !UNITY_EDITOR && UNITY_IOS
        private const string DefaultTagValue = "Unity";

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Debug(string tag, char[] message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Warning(string tag, char[] message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Error(string tag, char[] message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Fatal(string tag, char[] message);
#endif

        protected override void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
#if !UNITY_EDITOR && UNITY_IOS
            var tag = logMessage.Tag.HasValue() ? logMessage.Tag.Value : DefaultTagValue;
            var logLevel = logMessage.LogLevel;

            switch (logLevel)
            {
                case LogLevel.Debug:
                    NativeLoggerIos_Debug(tag, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Warning:
                    NativeLoggerIos_Warning(tag, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Error:
                    NativeLoggerIos_Error(tag, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Fatal:
                    NativeLoggerIos_Fatal(tag, renderedMessage.arrayFromPool);
                    break;
            }
#endif
        }
    }
}
using Openmygame.Logger.Base;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;
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

        protected override void LogRenderedMessage(
            in LogMessage logMessage, Tag tag, ref ValueStringBuilder renderedMessage)
        {
#if !UNITY_EDITOR && UNITY_IOS
            var tagValue = tag.HasValue() ? tag.Value : DefaultTagValue;

            switch (logMessage.LogLevel)
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
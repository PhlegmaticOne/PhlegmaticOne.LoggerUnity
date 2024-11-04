using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
#if !UNITY_EDITOR && UNITY_IOS
using Cysharp.Threading.Tasks;
using System.Runtime.InteropServices;
#endif

namespace OpenMyGame.LoggerUnity.Destinations.IOS
{
    public class IOSLogDestination : LogDestination<IOSLogConfiguration>
    {
#if !UNITY_EDITOR && UNITY_IOS
        private const string DefaultTagValue = "Unity";

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Debug(string tag, string message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Warning(string tag, string message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Error(string tag, string message);

        [DllImport("__Internal")]
        private static extern void NativeLoggerIos_Fatal(string tag, string message);
#endif

        public override string DestinationName => LogDestinationsSupported.IOS;

        protected override void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
#if !UNITY_EDITOR && UNITY_IOS
            var tag = logMessage.Tag.HasValue() ? logMessage.Tag.Value : DefaultTagValue;
            var logLevel = logMessage.LogLevel;
            LogMessageInMainThread(tag, logLevel, renderedMessage.ToString()).Forget();
#endif
        }
        
#if !UNITY_EDITOR && UNITY_IOS
        private static async UniTaskVoid LogMessageInMainThread(
            string tag, LogLevel logLevel, string renderedMessage)
        {
            await UniTask.SwitchToMainThread();

            switch (logLevel)
            {
                case LogLevel.Debug:
                    NativeLoggerIos_Debug(tag, renderedMessage);
                    break;
                case LogLevel.Warning:
                    NativeLoggerIos_Warning(tag, renderedMessage);
                    break;
                case LogLevel.Error:
                    NativeLoggerIos_Error(tag, renderedMessage);
                    break;
                case LogLevel.Fatal:
                    NativeLoggerIos_Fatal(tag, renderedMessage);
                    break;
            }
        }
#endif
    }
}
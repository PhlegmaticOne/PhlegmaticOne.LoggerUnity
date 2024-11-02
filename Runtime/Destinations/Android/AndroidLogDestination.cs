using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using SpanUtilities.StringBuilders;
#if UNITY_ANDROID && !UNITY_EDITOR
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
#endif

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    internal class AndroidLogDestination : LogDestination<AndroidLogConfiguration>
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private const string DefaultTagValue = "Unity";

        private AndroidJavaObject _androidLogger;
#endif
        
        public override string DestinationName => LogDestinationsSupported.Android;

        protected override void OnInitializing()
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            _androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
#endif
        }

        protected override void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            if (_androidLogger is null)
            {
                return;
            }

            LogMessageInMainThread(logMessage, renderedMessage.ToString()).Forget();
#endif
        }
        
#if UNITY_ANDROID && !UNITY_EDITOR
        public override void Dispose()
        {
            _androidLogger.Dispose();
            _androidLogger = null;
            base.Dispose();
        }

        private async UniTaskVoid LogMessageInMainThread(LogMessage logMessage, string renderedMessage)
        {
            var methodName = ToNativeMethodName(logMessage.LogLevel);
            var tag = logMessage.Tag.HasValue() ? logMessage.Tag.Value : DefaultTagValue;
            await UniTask.SwitchToMainThread();
            _androidLogger.CallStatic(methodName, tag, renderedMessage);
        }

        private static string ToNativeMethodName(LogLevel logLevel)
        {
            return logLevel switch
            {
                LogLevel.Debug => "Debug",
                LogLevel.Warning => "Warning",
                LogLevel.Error => "Error",
                LogLevel.Fatal => "Fatal",
                _ => throw new ArgumentOutOfRangeException(nameof(logLevel), logLevel, null)
            };
        }
#endif
    }
}
using System;
using Cysharp.Threading.Tasks;
using OpenMyGame.LoggerUnity.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    public class AndroidLogDestination : LogDestination<AndroidLogConfiguration>
    {
        private const string DefaultTag = "Unity";
        
        private AndroidJavaObject _androidLogger;
        
        public override string DestinationName => "Android";

        protected override void OnInitializing()
        {
            _androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
        }

        protected override void LogRenderedMessage(LogMessage logMessage, string renderedMessage, Span<object> parameters)
        {
            if (_androidLogger is null)
            {
                return;
            }

            LogMessageInMainThread(logMessage, renderedMessage).Forget();
        }

        public override void Release()
        {
            _androidLogger.Dispose();
            _androidLogger = null;
            base.Release();
        }

        private async UniTaskVoid LogMessageInMainThread(LogMessage logMessage, string renderedMessage)
        {
            var methodName = ToNativeMethodName(logMessage.LogLevel);
            var tag = logMessage.Tag?.Tag ?? DefaultTag;
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
    }
}
using System;
using OpenMyGame.LoggerUnity.Base;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    public class AndroidDestination : LogDestination<AndroidConfiguration>
    {
        private const string DefaultTag = "Unity";
        
        private AndroidJavaObject _androidLogger;
        
        public override string DestinationName => "Android";

        protected override void OnInitializing()
        {
            _androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
        }

        protected override void LogRenderedMessage(LogMessage logMessage, string renderedMessage)
        {
            if (_androidLogger is null)
            {
                return;
            }
            
            var methodName = ToNativeMethodName(logMessage.LogLevel);
            var tag = logMessage.Tag?.TagValue ?? DefaultTag;
            _androidLogger.CallStatic(methodName, tag, renderedMessage);
        }

        public override void Release()
        {
            _androidLogger.Dispose();
            _androidLogger = null;
            base.Release();
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
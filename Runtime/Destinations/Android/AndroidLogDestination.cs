using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Messages;
using SpanUtilities.StringBuilders;
#if UNITY_ANDROID && !UNITY_EDITOR
using OpenMyGame.LoggerUnity.Extensions;
using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using System.Buffers;
#endif

namespace OpenMyGame.LoggerUnity.Destinations.Android
{
    internal class AndroidLogDestination : LogDestination<AndroidLogConfiguration>
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private const string DefaultTagValue = "Unity";

        private AndroidParameterArrayPool _arrayPool;
        private AndroidJavaObject _androidLogger;
#endif
        
        public override string DestinationName => LogDestinationsSupported.Android;
        
#if UNITY_ANDROID && !UNITY_EDITOR
        protected override void OnInitializing()
        {
            _androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
            _arrayPool = new AndroidParameterArrayPool();
        }
#endif

        protected override void LogRenderedMessage(in LogMessage logMessage, ref ValueStringBuilder renderedMessage)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var tag = logMessage.Tag.HasValue() ? logMessage.Tag.Value : DefaultTagValue;
            var methodName = logMessage.LogLevel.ToStringCache();
            LogMessageInMainThread(methodName, tag, renderedMessage.arrayFromPool, renderedMessage.Length).Forget();
#endif
        }
        
#if UNITY_ANDROID && !UNITY_EDITOR
        public override void Dispose()
        {
            _androidLogger.Dispose();
            _androidLogger = null;
            base.Dispose();
        }

        private async UniTaskVoid LogMessageInMainThread(
            string methodName, string tag, char[] messageBuffer, int length)
        {
            await UniTask.SwitchToMainThread();
            
            var parameters = _arrayPool.Get();
            parameters[0] = tag;
            parameters[1] = messageBuffer;
            parameters[2] = length;
            _androidLogger.CallStatic(methodName, parameters);
            _arrayPool.Return(parameters);
        }
#endif
    }
}

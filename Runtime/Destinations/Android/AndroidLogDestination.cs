﻿using Openmygame.Logger.Base;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Messages.Tagging;
#if UNITY_ANDROID && !UNITY_EDITOR
using System.Runtime.InteropServices;
#endif

namespace Openmygame.Logger.Destinations.Android
{
    internal class AndroidLogDestination : LogDestination<AndroidLogConfiguration>
    {
#if UNITY_ANDROID && !UNITY_EDITOR
        private const string AndroidLoggerLibraryName = "AndroidLogger";
        private const string DefaultTagValue = "Unity";

        [DllImport(AndroidLoggerLibraryName)]
        private static extern void Debug(string tag, char[] message);
        
        [DllImport(AndroidLoggerLibraryName)]
        private static extern void Warning(string tag, char[] message);
        
        [DllImport(AndroidLoggerLibraryName)]
        private static extern void Error(string tag, char[] message);
        
        [DllImport(AndroidLoggerLibraryName)]
        private static extern void Fatal(string tag, char[] message);
#endif
        
        protected override void LogRenderedMessage(
            in LogMessage logMessage, Tag tag, ref ValueStringBuilder renderedMessage)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var tagValue = tag.HasValue() ? tag.Value : DefaultTagValue;

            switch (logMessage.LogLevel)
            {
                case LogLevel.Debug:
                    Debug(tagValue, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Warning:
                    Warning(tagValue, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Error:
                    Error(tagValue, renderedMessage.arrayFromPool);
                    break;
                case LogLevel.Fatal:
                    Fatal(tagValue, renderedMessage.arrayFromPool);
                    break;
            }
#endif
        }
    }
}

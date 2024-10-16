﻿namespace OpenMyGame.LoggerUnity.Configuration.Logger.Destinations.Platforms
{
    internal static class LoggerPlatformProvider
    {
        internal static LoggerPlatform GetPlatform()
        {
#if UNITY_EDITOR
            return LoggerPlatform.Editor;
#endif
            
#if UNITY_ANDROID
            return LoggerPlatform.Android;
#endif
            
#if UNITY_IOS
            return LoggerPlatform.Ios;
#endif
            
            return LoggerPlatform.None;
        }
    }
}
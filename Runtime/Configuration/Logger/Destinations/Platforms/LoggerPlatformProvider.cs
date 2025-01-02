namespace Openmygame.Logger.Configuration.Logger.Destinations.Platforms
{
    internal static class LoggerPlatformProvider
    {
        internal static bool HasPlatform(LoggerPlatform platform)
        {
            return platform.HasFlag(GetPlatform());
        }
        
        internal static LoggerPlatform GetPlatform()
        {
            #pragma warning disable CS0162
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
            #pragma warning restore CS0162
        }
    }
}
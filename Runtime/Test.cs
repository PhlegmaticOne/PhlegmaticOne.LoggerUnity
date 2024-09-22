using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.UnityDebug;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            // *. Unity Editor Log Window (format stacktrace)
            // 1. Tags window for default console + colors
            // 2. Testing
            // 3. Native logs

            // var androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
            // androidLogger.CallStatic("TestLog", "tag", "message");
            
            // var format =
            //     "<a href=\"Assets/Runtime/Test.cs\" line=\"21\">Assets/Runtime/Test.cs:21</a>";
            // Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", format);
            
            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag}#")
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Stacktrace}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
            
            Log.WithTag("Tag").Debug("Message {Parameter}", TimeSpan.Zero);
            Log.WithTag("Test").Debug("Message {Parameter}", TimeSpan.Zero);
        }
    }
}
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
            // 1. Stacktrace
            // 2. Unity Editor Log Window (format stacktrace)
            // 3. Native logs
            // 4. Testing
            
            // var androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
            // androidLogger.CallStatic("TestLog", "tag", "message");
            
            // var format =
            //     "<a href=\"Assets/Runtime/Test.cs\" line=\"21\">Assets/Runtime/Test.cs:21</a>";
            // Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", format);
            
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.MessagePartMaxSize = 789;
                    config.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
            
            Log.Debug("Message {Parameter}", TimeSpan.Zero);
        }
    }
}
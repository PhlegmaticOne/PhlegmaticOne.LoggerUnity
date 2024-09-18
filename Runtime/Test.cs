using System;
using System.Collections;
using System.Linq;
using System.Reflection;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.UnityDebug;
using UnityEditor;
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
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Stacktrace}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    //config.MessagePartMaxSize = 789;
                    config.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
            
            Log.Debug("Message {Parameter}", TimeSpan.Zero);

            // var consoleWindowType = Assembly.GetAssembly(typeof(Editor)).GetType("UnityEditor.ConsoleWindow");
            //
            // var consoleWindow = consoleWindowType
            //     .GetField("ms_ConsoleWindow", BindingFlags.Static | BindingFlags.NonPublic)!
            //     .GetValue(null);
            //
            // var setFilter = consoleWindowType
            //     .GetMethod("SetFilter", BindingFlags.Instance | BindingFlags.NonPublic);
            //
            // setFilter!.Invoke(consoleWindow, new object[] { "3" });
        }
    }
}
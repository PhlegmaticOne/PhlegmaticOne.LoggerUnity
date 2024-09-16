using System;
using OpenMyGame.LoggerUnity.Runtime.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log;
using OpenMyGame.LoggerUnity.Runtime.UnityDebug;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            // var androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
            // androidLogger.CallStatic("TestLog", "tag", "message");
            
            // var format =
            //     "<a href=\"Assets/Runtime/Test.cs\" line=\"21\">Assets/Runtime/Test.cs:21</a>";
            // Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", format);
            
            // Log.Logger = new LoggerBuilder()
            //     .LogToUnityDebug(config =>
            //     {
            //         config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception:ns}";
            //         config.MinimumLogLevel = LogLevel.Debug;
            //         config.MessagePartMaxSize = 789;
            //     })
            //     .CreateLogger();
            //
            // Log.Debug("Message {Parameter}", 1);

            var s = TimeSpan.FromSeconds(40).Add(TimeSpan.FromMilliseconds(4));
            var format = LogFormatPropertyUnityTime.FormatTime(s, "mm:ss.ms2");
            Debug.Log(format.ToString());
        }
        
        // private static void Test(
        //     [CallerFilePath] string filePath = "",
        //     [CallerLineNumber] int lineNumber = 0)
        // {
        //     rider64.exe [--line <number>] [--column <number>] <path ...>
        //     Debug.Log(filePath + lineNumber);
        // }
    }
}
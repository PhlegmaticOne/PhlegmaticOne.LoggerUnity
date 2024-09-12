using System;
using System.Collections.Generic;
using OpenMyGame.LoggerUnity.Runtime.Messages;
using OpenMyGame.LoggerUnity.Runtime.Parsing;
using OpenMyGame.LoggerUnity.Runtime.Properties.Base;
using OpenMyGame.LoggerUnity.Runtime.Properties.Container;
using OpenMyGame.LoggerUnity.Runtime.Properties.Log;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Runtime
{
    public class Test : MonoBehaviour
    {
        private void Start()
        {
            // var stacktrace = StackTraceUtility.ExtractStackTrace();
            // Debug.LogFormat("{0}", stacktrace);
            
            // var androidLogger = new AndroidJavaObject("com.openmygame.nativelogger.Logger");
            // androidLogger.CallStatic("TestLog", "tag", "message");

            //Parameters: UnityTime. Time, ThreadId, Stacktrace
            
            
            var formatProperties = new List<ILogFormatProperty>
            {
                new LogFormatPropertyException(),
                new LogFormatPropertyStacktrace(),
                new LogFormatPropertyTime(),
                new LogFormatPropertyLogLevel(),
                new LogFormatPropertyUnityTime(),
                new LogFormatPropertyNewLine()
            };

            var parameters = new object[]
            {
                "Test",
                123,
                '\n',
                new { Value = 1 },
                '\n',
                new Exception("Exception")
            };
            
            // var propertiesContainer = new LogMessagePartRendererParameters(parameters);
            //
            // var parser = new MessageFormatParser(propertiesContainer);
            //
            // var format = parser.Parse(
            //     "[{Time}] {Message}{NewLine}{Stacktrace}{NewLine}{Exception}", null);
            //
            // var render = format.Render(LogMessage.Empty);
            // Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", render);
            // Debug.Log("<a href=\"Assets/Scripts/MovablePlatform.cs\" line=\"7\">Assets/Scripts/MovablePlatform.cs:7</a>");
            
            // Log.Logger = LoggerBuilder.Create()
            //     .LogToUnityDebug(c =>
            //     {
            //         c.LogFormat = "{Time }{Message }{Stacktrace}";
            //         c.MinimumStacktraceLevel = LogLevel.Debug;
            //         c.MinimumLogLevel = LogLevel.Debug;
            //     })
            //     .CreateLogger();
            
            //Log.Debug("MessageOnly");
            //
            // var logWithTag = new LogWithTag("Test");
            // logWithTag.Debug("Message");
            
            // private static void Test(
            //     [CallerFilePath] string filePath = "",
            //     [CallerLineNumber] int lineNumber = 0)
            // {
            //     rider64.exe [--line <number>] [--column <number>] <path ...>
            //     Debug.Log(filePath + lineNumber);
            // }
        }
    }
}
using System;
using System.Reflection;
using OpenMyGame.LoggerUnity.Runtime.Base;
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


            // ReadOnlySpan<char> levelLogView = "Debug";
            // Span<char> result = stackalloc char[levelLogView.Length];
            // levelLogView.ToUpperInvariant(result);
            // Debug.Log(result.ToReadOnlySpan().ToString());
            
            // Log.Logger = new LoggerBuilder()
            //     .LogToUnityDebug(c =>
            //     {
            //         c.LogFormat = "[{Time}] {Message}";
            //         c.MinimumLogLevel = LogLevel.Debug;
            //         c.MessagePartMaxSize = 789;
            //     })
            //     .CreateLogger();
            //
            // Log.Debug("Message {Parameter}", 1);
            
            T("qwertyuiopp", 5);
        }

        private void T(string renderedMessage, int max)
        {
            var offset = 0;
            var messageSpan = renderedMessage.AsSpan();

            while (offset < renderedMessage.Length)
            {
                var endIndex = offset + max >= messageSpan.Length ? messageSpan.Length : offset + max;
                var messagePart = messageSpan[offset..endIndex];
                Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", messagePart.ToString());
                offset += max;
            }
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
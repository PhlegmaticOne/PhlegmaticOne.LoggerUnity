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
            
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(c =>
                {
                    c.LogFormat = "[{Time}] {Message}";
                    c.MinimumLogLevel = LogLevel.Debug;
                })
                .CreateLogger();
            
            Log.Debug("MessageOnly");
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
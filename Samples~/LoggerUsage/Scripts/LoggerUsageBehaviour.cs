using System;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Messages;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.LoggerUsage
{
    public class LoggerUsageBehaviour : MonoBehaviour
    {
        private void Awake()
        {
            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag}#")
                .SetIsCacheFormats(true)
                .SetIsPoolingEnabled(true)
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = false;
                    config.MessagePartMaxSize = 400;
                })
                .CreateLogger();
        }

        private void Start()
        {
            Log.DebugMessage().Log("Debug current time: {Time}", DateTime.Now);
            Log.WarningMessage().Log("Warning current time: {Time}", DateTime.Now);
            Log.ErrorMessage().Log("Error current time: {Time}", DateTime.Now);
            Log.FatalMessage().Log("Fatal current time: {Time}", DateTime.Now);
            
            Log.DebugMessage().WithTag("Time").Log("Debug current time with tag: {Time}", DateTime.Now);
            Log.WarningMessage().WithTag("Time").Log("Warning current time with tag: {Time}", DateTime.Now);
            Log.ErrorMessage().WithTag("Time").Log("Error current time with tag: {Time}", DateTime.Now);
            Log.FatalMessage().WithTag("Time").Log("Fatal current time with tag: {Time}", DateTime.Now);
            
            LogWithTag();
            
            Log.DebugMessage().Log("Debug complex object: {@Value}", new { Value = 5 });

            var systemException = new Exception("System failed");
            Log.FatalMessage()
                .WithTag("System")
                .WithException(systemException)
                .Log("System error: {Error}", "Something went wrong");
            
            Log.Exception(new Exception("Test exception"));
            
            try
            {
                throw new DivideByZeroException("Not available operation");
            }
            catch (DivideByZeroException e)
            {
                Log.Exception(e);
            }
        }

        private static void LogWithTag()
        {
            var logWithTag = new LogWithTag("Time");
            
            logWithTag
                .DebugMessage()
                .Log("Debug current time with log with tag: {Time}", DateTime.Now);
            
            logWithTag.Exception(new Exception("LogWithTag exception"));
        }
    }
}
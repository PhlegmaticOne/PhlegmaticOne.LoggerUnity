using System;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
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
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = true;
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

            var systemException = new Exception("System failed");
            Log.DebugMessage()
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
    }
}
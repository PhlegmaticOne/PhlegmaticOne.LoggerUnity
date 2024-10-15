using System;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Messages;
using UnityEngine;

namespace _Samples.LoggerUsage.Scenes
{
    public class Test : MonoBehaviour
    {
        private void Awake()
        {
            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag:c}#")
                .LogToUnityDebug(config =>
                {
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = true;
                    config.MessagePartMaxSize = 40000;
                })
                .CreateLogger();
        }

        private void Start()
        {
            Log.DebugMessage().Log("Debug current time: {Time}", DateTime.Now);
            Log.WarningMessage().Log("Warning current time: {Time}", DateTime.Now);
            Log.ErrorMessage().Log("Error current time: {Time}", DateTime.Now);
            Log.FatalMessage().Log("Fatal current time: {Time}", DateTime.Now);

            Log.DebugMessage().WithTag("BI").Log("Debug current time with tag: {Time}", DateTime.Now);
            Log.WarningMessage().WithTag("Time").Log("Warning current time with tag: {Time}", DateTime.Now);
            Log.ErrorMessage().WithTag("Time").Log("Error current time with tag: {Time}", DateTime.Now);
            Log.FatalMessage().WithTag("Time").Log("Fatal current time with tag: {Time}", DateTime.Now);
            
            Log.DebugMessage().Log("Debug complex object: {@Value}", new { Value = 5 });

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
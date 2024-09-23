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
                .SetTagFormat("#{Tag:c}#")
                .LogToUnityDebug(config =>
                {
                    config.LogFormat = "[{ThreadId}] {Message}{NewLine}{Exception:ns}";
                    config.MinimumLogLevel = LogLevel.Debug;
                    config.IsUnityStacktraceEnabled = true;
                })
                .CreateLogger();
        }

        private void Start()
        {
            Log.Debug("Debug current time: {Time}", DateTime.Now);
            Log.Warning("Warning current time: {Time}", DateTime.Now);
            Log.Error("Error current time: {Time}", DateTime.Now);
            Log.Fatal("Fatal current time: {Time}", DateTime.Now);
            
            Log.WithTag("Time").Debug("Debug current time with tag: {Time}", DateTime.Now);
            Log.WithTag("Time").Warning("Warning current time with tag: {Time}", DateTime.Now);
            Log.WithTag("Time").Error("Error current time with tag: {Time}", DateTime.Now);
            Log.WithTag("Time").Fatal("Fatal current time with tag: {Time}", DateTime.Now);

            var systemException = new Exception("System failed");
            Log.WithTag("System").Error("System error: {Error}", "Something went wrong", systemException);
            
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
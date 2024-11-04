using System;
using OpenMyGame.LoggerUnity.Destinations.Android.Extensions;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.LoggerUsage
{
    public class LoggerUsageBehaviour : MonoBehaviour
    {
        private const string LongFormat = "Time: {Time}; Weather: {Weather}, Velocity: {Velocity}; Mass: {Mass}; Acceleration: {Acceleration}";

        private void Awake()
        {
            //Log.Logger = LoggerBuilder.FromConfig(LoggerConfig.Load());
            
            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag}#")
                .LogToUnityDebug(config =>
                {
                    config.RenderAs.PlainText();
                    config.MinimumLogLevel = LogLevel.Debug;
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
            
            Log.WithTag("Test").Debug(LongFormat, DateTime.Now, 42, 69, 420, 690);
            
            LogWithTag();
            
            Log.Debug("Debug complex object: {@Value}", new { Value = 5 });
            
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
            logWithTag.Debug("Debug current time with log with tag: {Time}", DateTime.Now);
            logWithTag.Exception(new Exception("LogWithTag exception"));
        }
    }
}
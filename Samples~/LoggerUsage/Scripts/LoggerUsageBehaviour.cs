using System;
using System.Threading.Tasks;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.LoggerUsage
{
    public class LoggerUsageBehaviour : MonoBehaviour
    {
        private static readonly LogWithTag LogTime = new("Time");
        private static readonly LogWithTag LogSystem = new("System");
        
        private const string LongFormat = "Time: {Time}; Weather: {Weather}, Velocity: {Velocity}; Mass: {Mass}; Acceleration: {Acceleration}";

        private void Awake()
        {
            //Log.Logger = LoggerBuilder.FromConfig(LoggerConfig.Load());
            
            Log.Logger = new LoggerBuilder()
                .SetTagFormat("#{Tag}#")
                .LogToUnityDebug(config =>
                {
                    config.RenderAs.PlainText("[Thread: {ThreadId}]: {Message}{NewLine}{Exception}");
                    config.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
        }

        private void Start()
        {
            Log.Debug("Debug current time: {Time}", DateTime.Now);
            Log.Warning("Warning current time: {Time}", DateTime.Now);
            Log.Error("Error current time: {Time}", DateTime.Now);
            Log.Fatal("Fatal current time: {Time}", DateTime.Now);

            Task.Run(ParallelLogging);
            
            LogTime.Debug("Debug current time with tag: {Time}", DateTime.Now);
            LogTime.Warning("Warning current time with tag: {Time}", DateTime.Now);
            LogTime.Error("Error current time with tag: {Time}", DateTime.Now);
            LogTime.Fatal("Fatal current time with tag: {Time}", DateTime.Now);
            
            Log.WithTag("Test").Debug(LongFormat, DateTime.Now, 42, 69, 420, 690);
            
            LogWithTag();
            
            Log.Debug("Debug complex object: {@Value}", new { Value = 5 });
            
            var systemException = new Exception("System failed");
            
            Log.FatalMessage("System", systemException)
                .Log("System error: {Error}", "Something went wrong");
            
            LogSystem.FatalMessage(systemException)
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

        private static void ParallelLogging()
        {
            LogTime.Debug("Debug current time with tag: {Time}", DateTime.Now);
            LogTime.Warning("Warning current time with tag: {Time}", DateTime.Now);
            LogTime.Error("Error current time with tag: {Time}", DateTime.Now);
            LogTime.Fatal("Fatal current time with tag: {Time}", DateTime.Now);
        }

        private static void LogWithTag()
        {
            var logWithTag = new LogWithTag("Time");
            logWithTag.Debug("Debug current time with log with tag: {Time}", DateTime.Now);
            logWithTag.Exception(new Exception("LogWithTag exception"));
        }
    }
}
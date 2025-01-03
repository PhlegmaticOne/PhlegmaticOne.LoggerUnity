using System;
using System.Threading.Tasks;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using Openmygame.Logger.Formats.Log.PlainText;
using UnityEngine;
using ILogger = Openmygame.Logger.Base.ILogger;

namespace Openmygame.Logger.LoggerUsage
{
    public class LoggerUsageBehaviour : MonoBehaviour
    {
        private ILogger _logTime;
        private ILogger _logSystem;
        
        private const string LongFormat = "Time: {Time}; Weather: {Weather}, Velocity: {Velocity}; Mass: {Mass}; Acceleration: {Acceleration}";

        private void Awake()
        {
            //Log.Logger = LoggerBuilder.FromConfig(LoggerConfig.Load());
            
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(config =>
                {
                    config.RenderAs.PlainText("[Thread: {ThreadId}]: {Message}{NewLine}{Exception}");
                    config.IsUnityStacktraceEnabled = true;
                    config.ColorizeParameters();
                })
                .CreateLogger();

            _logTime = Log.Tag("Time");
            _logSystem = Log.Subsystem("Time", "System");
        }

        private void Start()
        {
            Log.Debug("Debug current time: {Time}", DateTime.Now);
            Log.Warning("Warning current time: {Time}", DateTime.Now);
            Log.Error("Error current time: {Time}", DateTime.Now);
            Log.Fatal("Fatal current time: {Time}", DateTime.Now);
            
            Task.Run(ParallelLogging);
            
            _logTime.Debug("Debug current time with tag: {Time}", DateTime.Now);
            _logTime.Warning("Warning current time with tag: {Time}", DateTime.Now);
            _logTime.Error("Error current time with tag: {Time}", DateTime.Now);
            _logTime.Fatal("Fatal current time with tag: {Time}", DateTime.Now);
            
            _logSystem.Debug("Debug current time with tag: {Time}", DateTime.Now);
            _logSystem.Warning("Warning current time with tag: {Time}", DateTime.Now);
            _logSystem.Error("Error current time with tag: {Time}", DateTime.Now);
            _logSystem.Fatal("Fatal current time with tag: {Time}", DateTime.Now);
            
            Log.TagDebug("Time", LongFormat, DateTime.Now, 42, 69, 420, 690);
            
            LogWithTag();
            
            Log.Debug("Debug complex object: {@Value}", new { Value = 5 });
            
            var systemException = new Exception("System failed");
            
            Log.TagException("System", systemException, "System error: {Error}", "Something went wrong");

            _logSystem.Exception(systemException, "System error: {Error}", "Something went wrong");
            
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

        private void ParallelLogging()
        {
            _logTime.Debug("Debug current time with tag: {Time}", DateTime.Now);
            _logTime.Warning("Warning current time with tag: {Time}", DateTime.Now);
            _logTime.Error("Error current time with tag: {Time}", DateTime.Now);
            _logTime.Fatal("Fatal current time with tag: {Time}", DateTime.Now);
        }

        private static void LogWithTag()
        {
            var logWithTag = Log.Tag("Time");
            logWithTag.Debug("Debug current time with log with tag: {Time}", DateTime.Now);
            logWithTag.Exception(new Exception("LogWithTag exception"));
        }
    }
}
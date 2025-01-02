using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using Openmygame.Logger;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Destinations.UnityDebug.Extensions;
using Openmygame.Logger.Formats.Log.PlainText;
using Openmygame.Logger.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.Editor
{
    [TestFixture]
    public class EditorStringBuilderNoStacktrace
    {
        private const int WarmupCount = 5;
        private const int IterationsCount = 80;
        private const int MeasurementsCount = 50;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(x =>
                {
                    x.RenderAs.PlainText(
                        "[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}{NewLine}{Exception}");
                    x.IsUnityStacktraceEnabled = false;
                })
                .CreateLogger();
        }

        [Test, Performance]
        public void Performance_DebugLog()
        {
            Measure
                .Method(LogMessageDebug)
                .WarmupCount(WarmupCount)
                .SampleGroup(new SampleGroup("Performance.DebugLog"))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }

        [Test, Performance]
        public void Performance_EditorLog()
        {
            Measure
                .Method(LogMessageEditor)
                .WarmupCount(WarmupCount)
                .SampleGroup(new SampleGroup("Performance.EditorLog"))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }

        [Test, Performance]
        public void Memory_DebugLog()
        {
            Measure
                .Method(LogMessageDebug)
                .WarmupCount(WarmupCount)
                .GC()
                .SampleGroup(new SampleGroup("Memory.DebugLog", SampleUnit.Megabyte))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }

        [Test, Performance]
        public void Memory_EditorLog()
        {
            Measure
                .Method(LogMessageEditor)
                .WarmupCount(WarmupCount)
                .GC()
                .SampleGroup(new SampleGroup("Memory.EditorLog", SampleUnit.Megabyte))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }
        
        private static void LogMessageDebug()
        {
            var sb = new StringBuilder()
                .AppendFormat("[Thread: {0}, ", Thread.CurrentThread.ManagedThreadId)
                .AppendFormat("LogLevel: {0}] ", LogLevel.Debug)
                .AppendFormat("#{0}# ", "Tag")
                .AppendFormat("Current time: {0:D}; ", DateTime.Now)
                .AppendFormat("Weather: {0}", 42)
                .AppendLine();
            
            Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", sb.ToString());
        }

        private static void LogMessageEditor()
        {
            Log.TagDebug("Test", "Current time: {Time:D}; Weather: {Weather}", DateTime.Now, 42);
        }
    }
}
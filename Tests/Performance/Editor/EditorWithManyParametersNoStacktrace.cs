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
    public class EditorWithManyParametersNoStacktrace
    {
        private const string Format = "Time: {Time}; Weather: {Weather}, Velocity: {Velocity}; Mass: {Mass}; Acceleration: {Acceleration}";

        private const int WarmupCount = 5;
        private const int IterationsCount = 30;
        private const int MeasurementsCount = 130;

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
                .SampleGroup(new SampleGroup("Performance.AndroidLog"))
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
                .AppendFormat("Time: {0}; ", DateTime.Now)
                .AppendFormat("Weather: {0}; ", 42)
                .AppendFormat("Velocity: {0}; ", 69)
                .AppendFormat("Mass: {0}; ", 420)
                .AppendFormat("Acceleration: {0}", 690)
                .AppendLine();
            
            Debug.LogFormat(LogType.Log, LogOption.NoStacktrace, null, "{0}", sb.ToString());
        }

        private static void LogMessageEditor()
        {
            Log.TagDebug("Test", Format, DateTime.Now, 42, 69, 420, 690);
        }
    }
}
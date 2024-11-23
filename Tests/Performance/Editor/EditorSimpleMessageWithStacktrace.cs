using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.Editor
{
    [TestFixture]
    public class EditorSimpleMessageWithStacktrace
    {
        private const int WarmupCount = 10;
        private const int IterationsCount = 100;
        private const int MeasurementsCount = 15;
        
        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(x =>
                {
                    x.RenderAs.PlainText("[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}{NewLine}{Exception}");
                    x.IsUnityStacktraceEnabled = true;
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
                .Method(() => Log.Debug("Test message"))
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
                .Method(() => Log.Debug("Test message"))
                .WarmupCount(WarmupCount)
                .GC()
                .SampleGroup(new SampleGroup("Memory.EditorLog", SampleUnit.Megabyte))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }

        private static void LogMessageDebug()
        {
            var thread = 1;
            var loglevel = LogLevel.Debug;
            var message = "TestMessage";
            Debug.Log($"[Thread: {thread}, LogLevel: {loglevel}] {message}\n");
        }
    }
}

using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Destinations.Android.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.Android
{
    [TestFixture]
    public class LoggerAndroidWithoutStacktracePerformanceTests
    {
        private const int WarmupCount = 10;
        private const int IterationsCount = 100;
        private const int MeasurementsCount = 15;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStackTraces(false)
                .LogToAndroidLog(x =>
                {
                    x.RenderAs.PlainText(
                        "[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}{NewLine}{Exception}");
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
        public void Performance_AndroidLog()
        {
            Measure
                .Method(() => Log.Debug("Test message"))
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
        public void Memory_AndroidLog()
        {
            Measure
                .Method(() => Log.Debug("Test message"))
                .WarmupCount(WarmupCount)
                .GC()
                .SampleGroup(new SampleGroup("Memory.AndroidLog", SampleUnit.Megabyte))
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
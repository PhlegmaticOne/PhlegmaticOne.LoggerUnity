using NUnit.Framework;
using Openmygame.Logger;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Destinations.IOS.Extensions;
using Openmygame.Logger.Formats.Log.PlainText;
using Openmygame.Logger.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.IOS
{
    [TestFixture]
    public class IOSSimpleMessageWithStacktrace
    {
        private const int WarmupCount = 10;
        private const int IterationsCount = 100;
        private const int MeasurementsCount = 15;
        
        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStacktrace(true)
                .LogToIOS(x =>
                {
                    x.RenderAs.PlainText("[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}{NewLine}{Exception}");
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
        public void Performance_IOSLog()
        {
            Measure
                .Method(() => Log.Debug("Test message"))
                .WarmupCount(WarmupCount)
                .SampleGroup(new SampleGroup("Performance.IOSLog"))
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
        public void Memory_IOSLog()
        {
            Measure
                .Method(() => Log.Debug("Test message"))
                .WarmupCount(WarmupCount)
                .GC()
                .SampleGroup(new SampleGroup("Memory.IOSLog", SampleUnit.Megabyte))
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

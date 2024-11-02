using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Destinations.Android.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance
{
    [TestFixture]
    public class LoggerAndroidPerformanceTests
    {
        private const int WarmupCount = 10;
        private const int IterationsCount = 100;
        private const int MeasurementsCount = 10;
        
        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStackTraces(true)
                .LogToAndroidLog(x =>
                {
                    x.RenderAs.PlainText("[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}{NewLine}{Exception}");
                })
                .CreateLogger();
        }
        
        [Test, Performance]
        public void Performance_DebugLog()
        {
            Measure
                .Method(() =>
                {
                    Debug.Log("[Thread: 1, LogLevel: Debug] Test message\n");
                })
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
                .Method(() =>
                {
                    Log.Debug("Test message");
                })
                .WarmupCount(WarmupCount)
                .SampleGroup(new SampleGroup("Performance.AndroidLog"))
                .IterationsPerMeasurement(IterationsCount)
                .MeasurementCount(MeasurementsCount)
                .Run();
        }
    }
}

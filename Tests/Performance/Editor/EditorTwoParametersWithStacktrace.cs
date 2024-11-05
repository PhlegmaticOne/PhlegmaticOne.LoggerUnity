using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.Editor
{
    [TestFixture]
    public class EditorTwoParametersWithStacktrace
    {
        private const int WarmupCount = 5;
        private const int IterationsCount = 30;
        private const int MeasurementsCount = 125;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .LogToUnityDebug(x =>
                {
                    x.RenderAs.PlainText("[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}");
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
            var thread = 1;
            var loglevel = LogLevel.Debug;
            var message = $"Current Time: {DateTime.Now:D}; Weather: {42}";
            var tag = "Test";
            Debug.Log($"[Thread: {thread}, LogLevel: {loglevel}] #{tag}# {message}");
        }

        private static void LogMessageEditor()
        {
            Log.WithTag("Test").Debug("Current time: {Time:D}; Weather: {Weather}", DateTime.Now, 42);
        }
    }
}
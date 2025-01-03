﻿using System;
using NUnit.Framework;
using Openmygame.Logger;
using Openmygame.Logger.Builders;
using Openmygame.Logger.Destinations.Android.Extensions;
using Openmygame.Logger.Formats.Log.PlainText;
using Openmygame.Logger.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.Android
{
    [TestFixture]
    public class AndroidTwoParametersWithStacktrace
    {
        private const int WarmupCount = 5;
        private const int IterationsCount = 30;
        private const int MeasurementsCount = 125;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStacktrace(true)
                .LogToAndroidLog(x =>
                {
                    x.RenderAs.PlainText("[Thread: {ThreadId}, LogLevel: {LogLevel}] {Message}");
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
                .Method(LogMessageAndroid)
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
                .Method(LogMessageAndroid)
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
            var message = $"Current Time: {DateTime.Now:D}; Weather: {42}";
            var tag = "Test";
            Debug.Log($"[Thread: {thread}, LogLevel: {loglevel}] #{tag}# {message}");
        }

        private static void LogMessageAndroid()
        {
            Log.TagDebug("Test", "Current time: {Time:D}; Weather: {Weather}", DateTime.Now, 42);
        }
    }
}
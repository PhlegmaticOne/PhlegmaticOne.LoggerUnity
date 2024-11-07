﻿using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Destinations.IOS.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.IOS
{
    [TestFixture]
    public class IOSTwoParametersWithStacktrace
    {
        private const int WarmupCount = 5;
        private const int IterationsCount = 30;
        private const int MeasurementsCount = 125;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStackTraces(true)
                .LogToIOS(x =>
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
        public void Performance_IOSLog()
        {
            Measure
                .Method(LogMessageIOS)
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
                .Method(LogMessageIOS)
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
            var message = $"Current Time: {DateTime.Now:D}; Weather: {42}";
            var tag = "Test";
            Debug.Log($"[Thread: {thread}, LogLevel: {loglevel}] #{tag}# {message}");
        }

        private static void LogMessageIOS()
        {
            Log.WithTag("Test").Debug("Current time: {Time:D}; Weather: {Weather}", DateTime.Now, 42);
        }
    }
}
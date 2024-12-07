using System;
using System.Text;
using System.Threading;
using NUnit.Framework;
using OpenMyGame.LoggerUnity;
using OpenMyGame.LoggerUnity.Builders;
using OpenMyGame.LoggerUnity.Destinations.IOS.Extensions;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using Unity.PerformanceTesting;
using UnityEngine;

namespace Tests.Performance.IOS
{
    [TestFixture]
    public class IOSWithManyParametersNoStacktrace
    {
        private const string Format = "Time: {Time}; Weather: {Weather}, Velocity: {Velocity}; Mass: {Mass}; Acceleration: {Acceleration}";

        private const int WarmupCount = 5;
        private const int IterationsCount = 30;
        private const int MeasurementsCount = 130;

        [OneTimeSetUp]
        public void Setup()
        {
            Log.Logger = new LoggerBuilder()
                .SetIsExtractStacktrace(false)
                .LogToIOS(x =>
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

        private static void LogMessageIOS()
        {
            Log.TagDebug("Test", Format, DateTime.Now, 42, 69, 420, 690);
        }
    }
}
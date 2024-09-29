using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Log
{
    [TestFixture]
    public class LogFormatParameterLogLevelTests
    {
        [TestCase(LogLevel.Debug)]
        [TestCase(LogLevel.Warning)]
        [TestCase(LogLevel.Error)]
        [TestCase(LogLevel.Fatal)]
        public void GetValue_ShouldReturnFullLogLevelName_WhenFormatHasNoLength(LogLevel logLevel)
        {
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel");
            var logMessage = new LogMessage(logLevel);
            
            var result = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
            
            Assert.AreEqual(logLevel.ToString(), result);
        }
        
        [TestCase(LogLevel.Debug, "Dbg")]
        [TestCase(LogLevel.Warning, "Wrn")]
        [TestCase(LogLevel.Error, "Err")]
        [TestCase(LogLevel.Fatal, "Ftl")]
        public void GetValue_ShouldReturnLevelNameWith3Length_WhenFormatHas3Length(LogLevel logLevel, string expected)
        {
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel:3");
            var logMessage = new LogMessage(logLevel);
            
            var result = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
            
            Assert.AreEqual(expected, result);
        }
        
        [TestCase(LogLevel.Debug, "D")]
        [TestCase(LogLevel.Warning, "W")]
        [TestCase(LogLevel.Error, "E")]
        [TestCase(LogLevel.Fatal, "F")]
        public void GetValue_ShouldReturnLevelNameWith1Length_WhenFormatHas3Length(LogLevel logLevel, string expected)
        {
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel:1");
            var logMessage = new LogMessage(logLevel);
            
            var result = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
            
            Assert.AreEqual(expected, result);
        }
        
        [TestCase(LogLevel.Debug, "DBG")]
        [TestCase(LogLevel.Warning, "WRN")]
        [TestCase(LogLevel.Error, "ERR")]
        [TestCase(LogLevel.Fatal, "FTL")]
        public void GetValue_ShouldReturnLevelNameUppercase_WhenFormatHasU(LogLevel logLevel, string expected)
        {
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel:u3");
            var logMessage = new LogMessage(logLevel);
            
            var result = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
            
            Assert.AreEqual(expected, result);
        }
        
        [TestCase(LogLevel.Debug, "dbg")]
        [TestCase(LogLevel.Warning, "wrn")]
        [TestCase(LogLevel.Error, "err")]
        [TestCase(LogLevel.Fatal, "ftl")]
        public void GetValue_ShouldReturnLevelNameLowercase_WhenFormatHasL(LogLevel logLevel, string expected)
        {
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel:l3");
            var logMessage = new LogMessage(logLevel);
            
            var result = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
            
            Assert.AreEqual(expected, result);
        }
    }
}
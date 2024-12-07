using NUnit.Framework;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages;
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
            //Arrange
            var parameter = new LogFormatParameterLogLevel();
            var messagePart = MessagePart.Parameter("LogLevel");
            var destination = new ValueStringBuilder();
            var logMessage = new LogMessage(null, null, logLevel);
            
            //Act
            parameter.Render(ref destination, messagePart, logMessage);
            
            //Assert
            Assert.AreEqual(logLevel.ToString(), destination.ToString());
        }
    }
}
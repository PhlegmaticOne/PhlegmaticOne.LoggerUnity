using NUnit.Framework;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Messages;
using Openmygame.Logger.Parameters.Log;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Tests.Runtime.Parameters.Log
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
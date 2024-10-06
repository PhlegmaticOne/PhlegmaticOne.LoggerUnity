using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Log
{
    [TestFixture]
    public class LogFormatParameterExceptionTests
    {
        [Test]
        public void GetValue_ShouldReturnExceptionWithoutStacktrace()
        {
            //Arrange
            var parameter = new LogFormatParameterException();
            var messagePart = MessagePart.Parameter("Exception:ns");
            const string expected = "Exception: Test exception";
            
            try
            {
                //Act
                throw new Exception("Test exception");
            }
            catch (Exception exception)
            {
                var logMessage = new LogMessage().WithException(exception);
                var actual = parameter.GetValue(messagePart, logMessage, "").ToString();
                
                //Assert
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
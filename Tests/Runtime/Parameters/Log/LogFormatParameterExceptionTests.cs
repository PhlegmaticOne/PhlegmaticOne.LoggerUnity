using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Log
{
    [TestFixture]
    public class LogFormatParameterExceptionTests
    {
        [Test]
        public void GetValue_ShouldReturnValueEqualToExceptionToString_WhenParameterHasNoFormat()
        {
            var parameter = new LogFormatParameterException();
            var messagePart = MessagePart.Parameter("Exception");
            
            try
            {
                throw new Exception("Test exception");
            }
            catch (Exception exception)
            {
                var expected = exception.ToString();
                
                var logMessage = new LogMessage(exception);
                var actual = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
                
                Assert.AreEqual(expected, actual);
            }
        }
        
        [Test]
        public void GetValue_ShouldReturnExceptionWithoutStacktrace_WhenParameterFormatIsNS()
        {
            var parameter = new LogFormatParameterException();
            var messagePart = MessagePart.Parameter("Exception:ns");
            const string expected = "Exception: Test exception";
            
            try
            {
                throw new Exception("Test exception");
            }
            catch (Exception exception)
            {
                var logMessage = new LogMessage(exception);
                var actual = parameter.GetValue(messagePart, logMessage, Span<object>.Empty).ToString();
                
                Assert.AreEqual(expected, actual);
            }
        }
    }
}
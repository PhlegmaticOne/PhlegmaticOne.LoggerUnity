﻿using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

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
            var destination = new ValueStringBuilder();
            ValueStringBuilder testMessage = string.Empty;
            const string expected = "Exception: Test exception";
            
            try
            {
                //Act
                throw new Exception("Test exception");
            }
            catch (Exception exception)
            {
                var message = new LogMessage().WithException(exception);
                parameter.Render(ref destination, ref testMessage, messagePart, message);
                
                //Assert
                Assert.AreEqual(expected, destination.ToString());
            }
        }
    }
}
using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parameters.Processors.Colors;
using OpenMyGame.LoggerUnity.Parsing.MessageFormats;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parsing.MessageFormats
{
    [TestFixture]
    public class MessageFormatLogMessageTests
    {
        [Test]
        public void Render_ShouldRenderExpectedValue()
        {
            var messageParts = new[]
            {
                MessagePart.Message("Test "),
                MessagePart.Parameter("Value")
            };

            var parameters = new object[]
            {
                "Value"
            };

            var logMessage = new LogMessage(LogLevel.Debug);

            var messageFormat = new MessageFormatLogMessage(messageParts,
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new ParameterPostRenderProcessor());

            var renderedMessage = messageFormat.Render(logMessage, parameters);
            
            Assert.AreEqual("Test Value", renderedMessage);
        }
        
        [Test]
        public void Render_ShouldRenderExpectedValue_WhenObjectShouldBeSerialized()
        {
            var messageParts = new[]
            {
                MessagePart.Message("Test "),
                MessagePart.Parameter("@Value")
            };

            var parameters = new object[]
            {
                new { Value = 5, Name = "Name" }
            };

            var logMessage = new LogMessage(LogLevel.Debug);

            var messageFormat = new MessageFormatLogMessage(messageParts,
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new ParameterPostRenderProcessor());

            var renderedMessage = messageFormat.Render(logMessage, parameters);
            
            Assert.AreEqual("Test {\"Value\":5,\"Name\":\"Name\"}", renderedMessage);
        }
    }
}
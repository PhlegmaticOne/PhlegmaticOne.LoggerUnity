using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Stacktrace;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Formats.Log
{
    [TestFixture]
    public class LogFormatPlainTextTests
    {
        [Test]
        public void Render_ShouldCorrectlyRenderMessage()
        {
            //Arrange
            var format = new MessageFormatParser().Parse("[Thread: {ThreadId}, Id: {MessageId}] {Message}");
            ValueStringBuilder message = "Test message";
            var logFormat = new LogFormatPlainText(
                format, false, LoggerStaticData.LogFormatParameters, new LogParameterPostRenderer());
            var logMessage = new LogMessage(69, LogLevel.Fatal, LogStacktrace.Empty, null);
            
            //Act
            var renderedMessage = logFormat.Render(
                logMessage, ref message, Array.Empty<MessagePart>(), Span<object>.Empty);
            
            //Assert
            Assert.AreEqual("[Thread: 1, Id: 69] Test message", renderedMessage.ToString());
        }
    }
}
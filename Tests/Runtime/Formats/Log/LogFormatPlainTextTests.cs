using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing;
using OpenMyGame.LoggerUnity.Parsing.Models;

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
            var logFormat = new LogFormatPlainText(
                format, false, LoggerStaticData.LogFormatParameters,
                new LogParameterPostRenderer(),
                new PoolProvider(false));
            var logMessage = new LogMessage(69, LogLevel.Fatal, LogStacktrace.Empty, null);
            
            //Act
            var renderedMessage = logFormat.Render(
                logMessage, "Test message", Array.Empty<MessagePart>(), Span<object>.Empty);
            
            //Assert
            Assert.AreEqual("[Thread: 1, Id: 69] Test message", renderedMessage);
        }
    }
}
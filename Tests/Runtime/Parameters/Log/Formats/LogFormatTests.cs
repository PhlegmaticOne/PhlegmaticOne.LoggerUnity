using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Parameters.Log.Formats;
using OpenMyGame.LoggerUnity.Parameters.Log.Processors;
using OpenMyGame.LoggerUnity.Parsing;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Log.Formats
{
    [TestFixture]
    public class LogFormatTests
    {
        [Test]
        public void Render_ShouldCorrectlyRenderMessage()
        {
            //Arrange
            var format = new MessageFormatParser().Parse("[Thread: {ThreadId}, Id: {MessageId}] {Message}");
            var logFormat = new LogFormat(
                false, format, LoggerStaticData.LogFormatParameters,
                new LogParameterPostRenderProcessor(),
                new PoolProvider(false));
            var logMessage = new LogMessage(69, LogLevel.Fatal, LogStacktrace.Empty, null);
            
            //Act
            var renderedMessage = logFormat.Render(logMessage, "Test message");
            
            //Assert
            Assert.AreEqual("[Thread: 1, Id: 69] Test message", renderedMessage);
        }
    }
}
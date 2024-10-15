using System.Collections.Generic;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging;
using OpenMyGame.LoggerUnity.Infrastructure.Pools.Providers;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.PartLogging
{
    [TestFixture]
    public class PartLoggingMessageFormatTests
    {
        [Test]
        public void CreatePart_ShouldThrowException_WhenFormatHasUnknownParameterName()
        {
            //Arrange
            const string format = "[Id: {TestId}, Part: {PartIndex}/{PartsCount}";
            var messageFormat = new PartLoggingMessageFormat(format, new PoolProvider(false));
            var parameters = new PartLoggingParameters();

            //Act
            //Assert
            Assert.Throws<KeyNotFoundException>(() => messageFormat.CreatePart(parameters));
        }
        
        [Test]
        public void CreatePart_ShouldFormatMessageWithProvidedParameters()
        {
            //Arrange
            const string format = "[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}";
            var messageFormat = new PartLoggingMessageFormat(format, new PoolProvider(false));
            var parameters = messageFormat.CreateParameters(messageId: 42, partsCount: 69);
            parameters.UpdateMessage("Test message");
            
            //Act
            var messagePart = messageFormat.CreatePart(parameters);
            
            //Assert
            Assert.AreEqual("[Id: 42, Part: 0/69] Test message", messagePart);
        }
    }
}
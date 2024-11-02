using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.PartLogging;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.PartLogging
{
    [TestFixture]
    public class PartLoggingMessageFormatTests
    {
        [Test]
        public void CreatePart_ShouldFormatMessageWithProvidedParameters()
        {
            //Arrange
            const string format = "[Id: {MessageId}, Part: {PartIndex}/{PartsCount}] {MessagePart}";
            var messageFormat = new PartLoggingMessageFormat(format);
            var parameters = new PartLoggingParameters(messageId: 42, partsCount: 69);
            parameters.UpdateMessage("Test message".AsMemory());
            
            //Act
            var messagePart = messageFormat.CreatePart(ref parameters);
            
            //Assert
            Assert.AreEqual("[Id: 42, Part: 0/69] Test message", messagePart.ToString());
        }
    }
}
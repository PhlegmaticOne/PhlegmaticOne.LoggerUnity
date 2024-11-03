using NUnit.Framework;
using OpenMyGame.LoggerUnity.Messages;
using OpenMyGame.LoggerUnity.Messages.Factories;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Messages.Factories
{
    [TestFixture]
    public class LogMessageFactoryTests
    {
        [Test]
        public void CreateMessage_ShouldReturnMessageWithProvidedLogLevel()
        {
            //Arrange
            var factory = new LogMessageFactory();

            //Act
            var message = factory.CreateMessage(LogLevel.Debug, 0);
            
            //Assert
            Assert.AreEqual(LogLevel.Debug, message.LogLevel);
        }
        
        [Test]
        public void CreateMessage_ShouldReturnMessagesWithSequentialIds()
        {
            //Arrange
            var factory = new LogMessageFactory();

            //Act
            var message1 = factory.CreateMessage(LogLevel.Debug, 0);
            var message2 = factory.CreateMessage(LogLevel.Debug, 0);
            
            //Assert
            Assert.AreEqual(0, message1.Id);
            Assert.AreEqual(1, message2.Id);
        }
    }
}
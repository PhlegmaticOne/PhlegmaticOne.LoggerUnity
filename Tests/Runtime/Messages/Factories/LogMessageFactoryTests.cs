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
            var factory = new LogMessageFactory(isExtractStacktrace: false, startStacktraceDepthLevel: 0);

            //Act
            var message = factory.CreateMessage(LogLevel.Debug, 0);
            
            //Assert
            Assert.AreEqual(LogLevel.Debug, message.LogLevel);
        }
        
        [Test]
        public void CreateMessage_ShouldReturnMessagesWithSequentialIds()
        {
            //Arrange
            var factory = new LogMessageFactory(isExtractStacktrace: false, startStacktraceDepthLevel: 0);

            //Act
            var message1 = factory.CreateMessage(LogLevel.Debug, 0);
            var message2 = factory.CreateMessage(LogLevel.Debug, 0);
            
            //Assert
            Assert.AreEqual(0, message1.Id);
            Assert.AreEqual(1, message2.Id);
        }
        
        [TestCase(false, false)]
        [TestCase(true, true)]
        public void CreateMessage_ShouldReturnMessageWithExpectedStacktracePresence(
            bool isExtractStacktrace, bool hasStacktrace)
        {
            //Arrange
            var factory = new LogMessageFactory(isExtractStacktrace: isExtractStacktrace, startStacktraceDepthLevel: 0);

            //Act
            var message = factory.CreateMessage(LogLevel.Debug, 0);
            
            //Assert
            Assert.AreEqual(hasStacktrace, message.HasStacktrace());
        }
        
        [Test]
        public void CreateMessage_ShouldReturnMessageWithExceptedStacktrace()
        {
            //Arrange
            var factory = new LogMessageFactory(isExtractStacktrace: true, startStacktraceDepthLevel: 0);
            
            //Act
            //Скип первых трех строк стектрейса, чтобы он начинался с позиции текущего метода
            var message = factory.CreateMessage(LogLevel.Debug, stacktraceDepthLevel: 3);
            message.Stacktrace.TryGetUserCodeStacktrace(out var stacktrace);
            var stacktraceString = stacktrace.ToString();
            
            //Act
            Assert.IsTrue(stacktraceString
                .StartsWith("OpenMyGame.LoggerUnity.Tests.Runtime.Messages.Factories.LogMessageFactoryTests:CreateMessage_ShouldReturnMessageWithExceptedStacktrace"));
        }
    }
}
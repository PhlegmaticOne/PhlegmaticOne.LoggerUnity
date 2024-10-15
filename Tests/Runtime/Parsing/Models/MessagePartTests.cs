using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parsing.Models
{
    [TestFixture]
    public class MessagePartTests
    {
        [Test]
        public void SplitParameterToValueAndFormat_ShouldReturnOnlyValue_WhenMessagePartIsNotParameter()
        {
            //Arrange
            const string testMessage = "Test message";
            var messagePart = MessagePart.Message(testMessage);

            //Act
            messagePart.SplitParameterToValueAndFormat(out var value, out var format);
            
            //Assert
            Assert.AreEqual(value.ToString(), testMessage);
            Assert.AreEqual(format.ToString(), string.Empty);
        }
        
        [Test]
        public void SplitParameterToValueAndFormat_ShouldReturnOnlyValue_WhenMessagePartIsParameterWithoutParameters()
        {
            //Arrange
            const string testMessage = "Test message";
            var messagePart = MessagePart.Parameter(testMessage);

            //Act
            messagePart.SplitParameterToValueAndFormat(out var value, out var format);
            
            //Assert
            Assert.AreEqual(value.ToString(), testMessage);
            Assert.AreEqual(format.ToString(), string.Empty);
        }
        
        [TestCase("Message:u", "Message", "u")]
        [TestCase("Time:mm:ss", "Time", "mm:ss")]
        [TestCase("Debug:6", "Debug", "6")]
        [TestCase("Debug;6", "Debug;6", "")]
        public void SplitParameterToValueAndFormat_ShouldReturnValueAndFormat_WhenMessagePartIsParameterWithParameters(
            string message, string expectedValue, string expectedFormat)
        {
            //Arrange
            var messagePart = MessagePart.Parameter(message);

            //Act
            messagePart.SplitParameterToValueAndFormat(out var value, out var format);
            
            //Assert
            Assert.AreEqual(expectedValue, value.ToString());
            Assert.AreEqual(expectedFormat, format.ToString());
        }

        [Test]
        public void HasFormat_ShouldReturnFalse_WhenPartIsNotParameter()
        {
            //Arrange
            const string testMessage = "Test message";
            var messagePart = MessagePart.Message(testMessage);

            //Act
            var hasFormat = messagePart.HasFormat("Format");
            
            //Assert
            Assert.AreEqual(false, hasFormat);
        }
        
        [TestCase("Message:u", "u", true)]
        [TestCase("Message:u", "l", false)]
        [TestCase("Message", "u", false)]
        [TestCase("Message", "", false)]
        [TestCase("Message:u3", "u3", true)]
        [TestCase("Message:u3", "u", true)]
        [TestCase("Message:u3", "3", true)]
        [TestCase("Message:u3", "3u", false)]
        public void HasFormat_ShouldReturnExpectedValue(string message, string format, bool expectedValue)
        {
            //Arrange
            var messagePart = MessagePart.Parameter(message);

            //Act
            var hasFormat = messagePart.HasFormat(format);
            
            //Assert
            Assert.AreEqual(expectedValue, hasFormat);
        }
        
        [Test]
        public void TryGetFormat_ShouldReturnFalse_WhenPartIsNotParameter()
        {
            //Arrange
            const string testMessage = "Test message";
            var messagePart = MessagePart.Message(testMessage);

            //Act
            var hasFormat = messagePart.TryGetFormat(out var format);
            
            //Assert
            Assert.AreEqual(false, hasFormat);
            Assert.AreEqual(string.Empty, format.ToString());
        }
        
        [TestCase("Message:u", "u")]
        [TestCase("Message:u3", "u3")]
        [TestCase("Message:mm:ss", "mm:ss")]
        public void TryFormat_ShouldReturnExpectedFormat(string message, string expectedFormat)
        {
            //Arrange
            var messagePart = MessagePart.Parameter(message);

            //Act
            var hasFormat = messagePart.TryGetFormat(out var format);
            
            //Assert
            Assert.AreEqual(true, hasFormat);
            Assert.AreEqual(expectedFormat, format.ToString());
        }
    }
}
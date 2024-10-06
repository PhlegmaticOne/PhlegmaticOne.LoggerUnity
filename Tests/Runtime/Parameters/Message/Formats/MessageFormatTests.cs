using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Formats;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message.Formats
{
    [TestFixture]
    public class MessageFormatTests
    {
        [Test]
        public void Render_ShouldRenderEmptyString_WhenParametersIsEmpty()
        {
            //Arrange
            var messageParts = Array.Empty<MessagePart>();

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterPostRenderProcessor());

            //Act
            var renderedMessage = messageFormat.Render(messageParts, parameters);
            
            //Assert
            Assert.AreEqual(string.Empty, renderedMessage);
        }
        
        [Test]
        public void Render_ShouldRenderExpectedValue_WhenFormatDoesNotContainMessageFormatParameters()
        {
            //Arrange
            var messageParts = new[]
            {
                MessagePart.Message("Test "),
                MessagePart.Parameter("Value")
            };

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterPostRenderProcessor());

            //Act
            var renderedMessage = messageFormat.Render(messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test Value", renderedMessage);
        }
        
        [Test]
        public void Render_ShouldRenderExpectedValue_WhenFormatContainsMessageFormatParameters()
        {
            //Arrange
            var messageParts = new[]
            {
                MessagePart.Message("Test "),
                MessagePart.Parameter("Value:u"),
            };

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                LoggerStaticData.MessageFormatParameters,
                new MessageFormatParameterSerializer(),
                new MessageParameterPostRenderProcessor());

            //Act
            var renderedMessage = messageFormat.Render(messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test VALUE", renderedMessage);
        }
        
        [Test]
        public void Render_ShouldRenderExpectedValue_WhenObjectShouldBeSerialized()
        {
            //Arrange
            var messageParts = new[]
            {
                MessagePart.Message("Test "),
                MessagePart.Parameter("@Value")
            };

            var parameters = new object[]
            {
                new { Value = 5, Name = "Name" }
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterPostRenderProcessor());

            //Act
            var renderedMessage = messageFormat.Render(messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test {\"Value\":5,\"Name\":\"Name\"}", renderedMessage);
        }
    }
}
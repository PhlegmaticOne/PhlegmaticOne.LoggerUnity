using System;
using System.Collections.Generic;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Formats.Message;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Message.Base;
using OpenMyGame.LoggerUnity.Parameters.Message.Processors;
using OpenMyGame.LoggerUnity.Parameters.Message.Serializing;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Formats.Message
{
    [TestFixture]
    public class MessageFormatTests
    {
        [Test]
        public void Render_ShouldRenderEmptyString_WhenParametersIsEmpty()
        {
            //Arrange
            var messageParts = Array.Empty<MessagePart>();
            var destination = new ValueStringBuilder();

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterProcessor());

            //Act
            messageFormat.Render(ref destination, messageParts, parameters);
            
            //Assert
            Assert.AreEqual(string.Empty, destination.ToString());
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
            var destination = new ValueStringBuilder();

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterProcessor());

            //Act
            messageFormat.Render(ref destination, messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test Value", destination.ToString());
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
            var destination = new ValueStringBuilder();

            var parameters = new object[]
            {
                "Value"
            };

            var messageFormat = new MessageFormat(
                LoggerConfigurationData.MessageFormatParameters,
                new MessageFormatParameterSerializer(),
                new MessageParameterProcessor());

            //Act
            messageFormat.Render(ref destination, messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test VALUE", destination.ToString());
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
            var destination = new ValueStringBuilder();
            
            var parameters = new object[]
            {
                new { Value = 5, Name = "Name" }
            };

            var messageFormat = new MessageFormat(
                new Dictionary<Type, IMessageFormatParameter>(),
                new MessageFormatParameterSerializer(),
                new MessageParameterProcessor());

            //Act
            messageFormat.Render(ref destination, messageParts, parameters);
            
            //Assert
            Assert.AreEqual("Test {\"Value\":5,\"Name\":\"Name\"}", destination.ToString());
        }
    }
}
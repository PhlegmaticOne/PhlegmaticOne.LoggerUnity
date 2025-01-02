using System;
using System.Collections.Generic;
using NUnit.Framework;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Formats.Message;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message.Base;
using Openmygame.Logger.Parameters.Message.Processors;
using Openmygame.Logger.Parameters.Message.Serializing;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Tests.Runtime.Formats.Message
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
using System;
using System.Text;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors
{
    [TestFixture]
    public class LogParameterPostRendererColorizeTests
    {
        private static class Mocks
        {
            private class ParameterColorsViewConfigMock : IParameterColorsViewConfig
            {
                private readonly Color _logParameterColor;

                public ParameterColorsViewConfigMock(Color logParameterColor)
                {
                    _logParameterColor = logParameterColor;
                }
                
                public Color GetTagColor(string tag) => throw new NotImplementedException();

                public Color GetMessageParameterColor(object parameter) => throw new NotImplementedException();

                public Color GetLogParameterColor(string parameterKey, in ReadOnlySpan<char> renderedValue) => _logParameterColor;
            }
            
            public static IParameterColorsViewConfig ConfigWithLogParameterColor(Color color)
            {
                return new ParameterColorsViewConfigMock(color);
            }
        }
        
        [Test]
        public void Process_ShouldNotColorizeValue_WhenRenderedValueIsEmpty()
        {
            //Arrange
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterPostRendererColorize(viewConfig);
            var destination = new StringBuilder();
            var messagePart = MessagePart.Message("Test");
            
            //Act
            processor.Process(destination, messagePart, ReadOnlySpan<char>.Empty);
            
            //Assert
            Assert.AreEqual(string.Empty, destination.ToString());
        }
        
        [Test]
        public void Process_ShouldNotColorizeValue_WhenMessagePartIsMessageParameter()
        {
            //Arrange
            const string renderedValue = "Rendered message";
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterPostRendererColorize(viewConfig);
            var destination = new StringBuilder();
            var messagePart = MessagePart.Parameter(LogFormatParameterMessage.KeyParameter);
            
            //Act
            processor.Process(destination, messagePart, renderedValue);
            
            //Assert
            Assert.AreEqual(renderedValue, destination.ToString());
        }
        
        [Test]
        public void Process_ShouldNotColorizeValue_WhenMessagePartIsNewLineParameter()
        {
            //Arrange
            const string renderedValue = "\n";
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterPostRendererColorize(viewConfig);
            var destination = new StringBuilder();
            var messagePart = MessagePart.Parameter(LogFormatParameterNewLine.KeyParameter);
            
            //Act
            processor.Process(destination, messagePart, renderedValue);
            
            //Assert
            Assert.AreEqual(renderedValue, destination.ToString());
        }
        
        [Test]
        public void Process_ShouldColorizeValue_WhenMessagePartIsValidParameter()
        {
            //Arrange
            const string renderedValue = "Parameter value";
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterPostRendererColorize(viewConfig);
            var destination = new StringBuilder();
            var messagePart = MessagePart.Parameter(LogFormatParameterTime.KeyParameter);
            
            //Act
            processor.Process(destination, messagePart, renderedValue);
            
            //Assert
            Assert.AreEqual("<color=#FFFFFF>Parameter value</color>", destination.ToString());
        }
    }
}
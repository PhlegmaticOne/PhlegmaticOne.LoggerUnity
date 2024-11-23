using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parameters.Log;
using OpenMyGame.LoggerUnity.Parsing.Models;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors
{
    [TestFixture]
    public class LogParameterProcessorColorizeTests
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
                public Color GetLogParameterColor(string parameterKey, object parameterValue)
                {
                    return _logParameterColor;
                }
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
            var processor = new LogParameterProcessorColorize(viewConfig);
            var destination = new ValueStringBuilder();
            var messagePart = MessagePart.Message("Test");
            
            //Act
            processor.Preprocess(ref destination, messagePart, null);
            processor.Postprocess(ref destination, messagePart);
            
            //Assert
            Assert.AreEqual(string.Empty, destination.ToString());
        }
        
        [Test]
        public void Process_ShouldNotColorizeValue_WhenMessagePartIsNewLineParameter()
        {
            //Arrange
            const string renderedValue = "\n";
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterProcessorColorize(viewConfig);
            var destination = new ValueStringBuilder();
            var messagePart = MessagePart.Parameter(LogFormatParameterNewLine.KeyParameter);
            
            //Act
            processor.Preprocess(ref destination, messagePart, null);
            destination.Append(renderedValue);
            processor.Postprocess(ref destination, messagePart);
            
            //Assert
            Assert.AreEqual(renderedValue, destination.ToString());
        }
        
        [Test]
        public void Process_ShouldColorizeValue_WhenMessagePartIsValidParameter()
        {
            //Arrange
            const string renderedValue = "Parameter value";
            var viewConfig = Mocks.ConfigWithLogParameterColor(Color.white);
            var processor = new LogParameterProcessorColorize(viewConfig);
            var destination = new ValueStringBuilder();
            var messagePart = MessagePart.Parameter(LogFormatParameterTime.KeyParameter);
            
            //Act
            processor.Preprocess(ref destination, messagePart, null);
            destination.Append(renderedValue);
            processor.Postprocess(ref destination, messagePart);
            
            //Assert
            Assert.AreEqual("<color=#FFFFFF>Parameter value</color>", destination.ToString());
        }
    }
}
using System;
using System.Text;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors
{
    [TestFixture]
    public class MessageParameterPostRendererColorizeTests
    {
        private static class Mocks
        {
            private class ParameterColorsViewConfigColor : IParameterColorsViewConfig
            {
                private readonly Color _color;

                public ParameterColorsViewConfigColor(Color color)
                {
                    _color = color;
                }
                
                public Color GetTagColor(string tag) => _color;

                public Color GetMessageParameterColor(object parameter) => _color;

                public Color GetLogParameterColor(in ReadOnlySpan<char> parameterKey, in ReadOnlySpan<char> renderedValue) => _color;
            }
            
            public static IParameterColorsViewConfig ConfigWithMessageParameterColor(Color color)
            {
                return new ParameterColorsViewConfigColor(color);
            }
            
            public static IParameterColorsViewConfig ConfigWithTagColor(Color color)
            {
                return new ParameterColorsViewConfigColor(color);
            }
        }
        
        [TestCase("#FFFFFF", "Test", "<color=#FFFFFF>Test</color>")]
        [TestCase("#000000", "123", "<color=#000000>123</color>")]
        [TestCase("#123456", "oooo", "<color=#123456>oooo</color>")]
        public void Process_ShouldFillStringBuilderWithExpectedMessageParameterColor(
            string colorString, string renderedParameter, string expected)
        {
            //Arrange
            var builder = new StringBuilder();
            ColorUtility.TryParseHtmlString(colorString, out var color);
            var viewConfig = Mocks.ConfigWithMessageParameterColor(color);
            var processor = new MessageParameterPostRendererColorize(viewConfig);
            
            //Act
            processor.Process(builder, renderedParameter, new object());
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
        
        [TestCase("#FFFFFF", "Test", "<color=#FFFFFF>Test</color>")]
        [TestCase("#000000", "123", "<color=#000000>123</color>")]
        [TestCase("#123456", "oooo", "<color=#123456>oooo</color>")]
        public void Process_ShouldFillStringBuilderWithExpectedTagColor(
            string colorString, string tag, string expected)
        {
            //Arrange
            ColorUtility.TryParseHtmlString(colorString, out var color);
            var viewConfig = Mocks.ConfigWithTagColor(color);
            var builder = new StringBuilder();
            var logTag = LogTag.TagOnly(tag);
            var processor = new MessageParameterPostRendererColorize(viewConfig);
            
            //Act
            processor.Process(builder, tag, logTag);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
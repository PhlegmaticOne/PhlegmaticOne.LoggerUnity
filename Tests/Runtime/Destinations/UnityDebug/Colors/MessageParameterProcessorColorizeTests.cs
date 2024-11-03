using NUnit.Framework;
using OpenMyGame.LoggerUnity.Configuration.Colors.Base;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors
{
    [TestFixture]
    public class MessageParameterProcessorColorizeTests
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

                public Color GetLogParameterColor(string parameterKey, object paramterValue) => _color;
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
            var builder = new ValueStringBuilder();
            ColorUtility.TryParseHtmlString(colorString, out var color);
            var viewConfig = Mocks.ConfigWithMessageParameterColor(color);
            var processor = new MessageParameterProcessorColorize(viewConfig);
            
            //Act
            processor.Preprocess(ref builder, renderedParameter);
            builder.Append(renderedParameter);
            processor.Postprocess(ref builder, renderedParameter);
            
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
            var builder = new ValueStringBuilder();
            var logTag = new LogTag(tag);
            var processor = new MessageParameterProcessorColorize(viewConfig);
            
            //Act
            processor.Preprocess(ref builder, logTag);
            builder.Append(tag);
            processor.Postprocess(ref builder, logTag);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
using System.Text;
using Moq;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig.Base;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors
{
    [TestFixture]
    public class MessageParameterPostRenderProcessorColorizeTests
    {
        private static class Mocks
        {
            public static IParameterColorsViewConfig ConfigWithMessageParameterColor(Color color)
            {
                var mock = new Mock<IParameterColorsViewConfig>();
                mock.Setup(x => x.GetMessageParameterColor(It.IsAny<object>())).Returns(color);
                return mock.Object;
            }
            
            public static IParameterColorsViewConfig ConfigWithTagColor(Color color)
            {
                var mock = new Mock<IParameterColorsViewConfig>();
                mock.Setup(x => x.GetTagColor(It.IsAny<string>())).Returns(color);
                return mock.Object;
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
            var processor = new MessageParameterPostRenderProcessorColorize(viewConfig);
            
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
            var processor = new MessageParameterPostRenderProcessorColorize(viewConfig);
            
            //Act
            processor.Process(builder, tag, logTag);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
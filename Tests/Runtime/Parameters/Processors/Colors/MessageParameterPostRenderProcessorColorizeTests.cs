using System.Text;
using Moq;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.ViewConfig;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Processors.Colors
{
    [TestFixture]
    public class MessageParameterPostRenderProcessorColorizeTests
    {
        private static class Mocks
        {
            public static IParameterColorsViewConfig ConfigWithColor(Color color)
            {
                var mock = new Mock<IParameterColorsViewConfig>();
                mock.Setup(x => x.GetMessageParameterColor(It.IsAny<object>())).Returns(color);
                return mock.Object;
            }
        }
        
        [TestCase("#FFFFFF", "Test", "<color=#FFFFFF>Test</color>")]
        [TestCase("#000000", "123", "<color=#000000>123</color>")]
        [TestCase("#123456", "oooo", "<color=#123456>oooo</color>")]
        public void Process_ShouldFillStringBuilderWithExpectedColor(
            string colorString, string renderedParameter, string expected)
        {
            var builder = new StringBuilder();

            ColorUtility.TryParseHtmlString(colorString, out var color);
            var viewConfig = Mocks.ConfigWithColor(color);
            var processor = new MessageParameterPostRenderProcessorColorize(viewConfig);
            processor.Process(builder, renderedParameter, new object());
            
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
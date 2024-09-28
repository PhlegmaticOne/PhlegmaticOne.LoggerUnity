using System;
using Moq;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parameters.Message;
using OpenMyGame.LoggerUnity.Tagging;
using OpenMyGame.LoggerUnity.Tagging.Colors;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterTagTests
    {
        private static class Mocks
        {
            public static ITagColorProvider ColorProvider()
            {
                return ColorProvider(Color.white);
            }
            
            public static ITagColorProvider ColorProvider(Color color)
            {
                var mock = new Mock<ITagColorProvider>();
                mock.Setup(x => x.GetTagColor(It.IsAny<string>())).Returns(color);
                return mock.Object;
            }
        }
        
        [Test]
        public void Render_ShouldReturnTagValue_WhenFormatIsEmpty()
        {
            var parameter = new MessageFormatParameterTag(Mocks.ColorProvider());
            var tag = new LogTag("Tag");

            var actual = parameter.Render(tag, ReadOnlySpan<char>.Empty).ToString();
            
            Assert.AreEqual(tag.Tag, actual);
        }
        
        [Test]
        public void Render_ShouldReturnTagValue_WhenFormatNotEqualToC()
        {
            var parameter = new MessageFormatParameterTag(Mocks.ColorProvider());
            var tag = new LogTag("Tag");

            var actual = parameter.Render(tag, "u").ToString();
            
            Assert.AreEqual(tag.Tag, actual);
        }
        
        [Test]
        public void Render_ShouldReturnColorizedTagValue_WhenFormatIsEqualToC()
        {
            var colorProvider = Mocks.ColorProvider(Color.black);
            var parameter = new MessageFormatParameterTag(colorProvider);
            var tag = new LogTag("Tag");
            const string expected = "<color=#000000>Tag</color>";

            var actual = parameter.Render(tag, "c").ToString();
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(tag.Color, Color.black);
        }
    }
}
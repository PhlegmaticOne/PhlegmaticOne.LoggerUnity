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
        [Test]
        public void Render_ShouldReturnTagValue_WhenFormatIsEmpty()
        {
            var parameter = new MessageFormatParameterTag();
            var tag = LogTag.Transparent("Tag");

            var actual = parameter.Render(tag, ReadOnlySpan<char>.Empty).ToString();
            
            Assert.AreEqual(tag.Tag, actual);
        }
        
        [Test]
        public void Render_ShouldReturnTagValue_WhenFormatNotEqualToC()
        {
            var parameter = new MessageFormatParameterTag();
            var tag = LogTag.Transparent("Tag");

            var actual = parameter.Render(tag, "u").ToString();
            
            Assert.AreEqual(tag.Tag, actual);
        }
        
        [Test]
        public void Render_ShouldReturnColorizedTagValue_WhenFormatIsEqualToC()
        {
            var parameter = new MessageFormatParameterTag();
            var tag = LogTag.Colorized("Tag", Color.black);
            const string expected = "<color=#000000>Tag</color>";

            var actual = parameter.Render(tag, "c").ToString();
            
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(tag.Color, Color.black);
        }
    }
}
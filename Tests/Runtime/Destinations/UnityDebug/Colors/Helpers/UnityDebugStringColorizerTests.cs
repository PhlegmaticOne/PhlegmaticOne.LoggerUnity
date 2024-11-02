using System.Text;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Destinations.UnityDebug.Colors.Helpers;
using OpenMyGame.LoggerUnity.Messages.Tagging;
using UnityEngine;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Destinations.UnityDebug.Colors.Helpers
{
    [TestFixture]
    public class UnityDebugStringColorizerTests
    {
        [TestCase("#FFFFFF", "Test", "<color=#FFFFFF>Test</color>")]
        [TestCase("#000000", "123", "<color=#000000>123</color>")]
        [TestCase("#123456", "oooo", "<color=#123456>oooo</color>")]
        public void ColorizeString_ShouldReturnStringWithColorRichTextWrapper(string colorString, string value, string expected)
        {
            //Arrange
            ColorUtility.TryParseHtmlString(colorString, out var color);

            //Act
            var actual = UnityDebugStringColorizer.ColorizeString(value, color);
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [TestCase("#FFFFFF", "Test", "<color=#FFFFFF>Test</color>")]
        [TestCase("#000000", "123", "<color=#000000>123</color>")]
        [TestCase("#123456", "oooo", "<color=#123456>oooo</color>")]
        public void ColorizeNonHeapAlloc_ShouldAppendStringWithColorRichTextWrapperToStringBuilder(
            string colorString, string value, string expected)
        {
            //Arrange
            ColorUtility.TryParseHtmlString(colorString, out var color);
            var builder = new StringBuilder();

            //Act
            UnityDebugStringColorizer.ColorizeNonHeapAlloc(builder, value, color);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
        
        [Test]
        public void ColorizeNonHeapAlloc_ShouldAppendStringWithColorRichTextWrapperToStringBuilderWithPrefixAndPostfix()
        {
            //Arrange
            const string value = "Test";
            ColorUtility.TryParseHtmlString("#FFFFFF", out var color);
            var builder = new StringBuilder();

            //Act
            UnityDebugStringColorizer.ColorizeNonHeapAlloc(builder, value, color, "[#", "#]");
            
            //Assert
            Assert.AreEqual("<color=#FFFFFF>[#Test#]</color>", builder.ToString());
        }
    }
}
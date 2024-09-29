using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parameters.Message;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterStringTests
    {
        [Test]
        public void Render_ShouldReturnSameString_WhenFormatIsEmpty()
        {
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            var actual = parameter.Render(expected, ReadOnlySpan<char>.Empty).ToString();
            
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Render_ShouldReturnStringUppercase_WhenFormatIsU()
        {
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            var actual = parameter.Render(expected, "u").ToString();
            
            Assert.AreEqual(expected.ToUpper(), actual);
        }
        
        [Test]
        public void Render_ShouldReturnStringLowercase_WhenFormatIsC()
        {
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            var actual = parameter.Render(expected, "l").ToString();
            
            Assert.AreEqual(expected.ToLower(), actual);
        }
    }
}
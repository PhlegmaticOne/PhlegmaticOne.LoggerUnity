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
            //Arrange
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            //Act
            var actual = parameter.Render(expected, ReadOnlySpan<char>.Empty).ToString();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
        
        [Test]
        public void Render_ShouldReturnStringUppercase_WhenFormatIsU()
        {
            //Arrange
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            //Act
            var actual = parameter.Render(expected, "u").ToString();
            
            //Assert
            Assert.AreEqual(expected.ToUpper(), actual);
        }
        
        [Test]
        public void Render_ShouldReturnStringLowercase_WhenFormatIsC()
        {
            //Arrange
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();

            //Act
            var actual = parameter.Render(expected, "l").ToString();
            
            //Assert
            Assert.AreEqual(expected.ToLower(), actual);
        }
    }
}
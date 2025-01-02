using System;
using NUnit.Framework;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message;

namespace Openmygame.Logger.Tests.Runtime.Parameters.Message
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
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, expected, ReadOnlySpan<char>.Empty);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
        
        [Test]
        public void Render_ShouldReturnStringUppercase_WhenFormatIsU()
        {
            //Arrange
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, expected, "u");
            
            //Assert
            Assert.AreEqual(expected.ToUpper(), builder.ToString());
        }
        
        [Test]
        public void Render_ShouldReturnStringLowercase_WhenFormatIsC()
        {
            //Arrange
            const string expected = "Test string";
            var parameter = new MessageFormatParameterString();
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, expected, "l");
            
            //Assert
            Assert.AreEqual(expected.ToLower(), builder.ToString());
        }
    }
}
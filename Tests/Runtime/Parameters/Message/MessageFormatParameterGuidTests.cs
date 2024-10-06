using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parameters.Message;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterGuidTests
    {
        [TestCase("B")]
        [TestCase("N")]
        [TestCase("D")]
        [TestCase("P")]
        [TestCase("X")]
        [TestCase("")]
        public void Render_ShouldReturnCorrectFormattedGuidString(string format)
        {
            //Arrange
            var guid = Guid.NewGuid();
            var parameter = new MessageFormatParameterGuid();
            var expected = guid.ToString(format);
            
            //Act
            var actual = parameter.Render(guid, format).ToString();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
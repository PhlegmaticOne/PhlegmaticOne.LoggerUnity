using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parameters.Message;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterDateTimeTests
    {
        [TestCase("d")]
        [TestCase("s")]
        [TestCase("f")]
        [TestCase("h:mm:ss tt zz")]
        [TestCase("M/d/yy")]
        [TestCase("")]
        public void Render_ShouldReturnCorrectFormattedDateTimeString(string format)
        {
            //Arrange
            var dateTime = DateTime.Now;
            var parameter = new MessageFormatParameterDateTime();
            var expected = dateTime.ToString(format);
            
            //Act
            var actual = parameter.Render(dateTime, format).ToString();
            
            //Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
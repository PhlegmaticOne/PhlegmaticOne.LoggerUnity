using System;
using NUnit.Framework;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message;

namespace Openmygame.Logger.Tests.Runtime.Parameters.Message
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
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, dateTime, format);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
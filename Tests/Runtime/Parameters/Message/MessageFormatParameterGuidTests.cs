using System;
using NUnit.Framework;
using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parameters.Message;

namespace Openmygame.Logger.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterGuidTests
    {
        [TestCase("B")]
        [TestCase("N")]
        [TestCase("D")]
        [TestCase("P")]
        [TestCase("")]
        public void Render_ShouldReturnCorrectFormattedGuidString(string format)
        {
            //Arrange
            var guid = Guid.NewGuid();
            var parameter = new MessageFormatParameterGuid();
            var expected = guid.ToString(format);
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, guid, format);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
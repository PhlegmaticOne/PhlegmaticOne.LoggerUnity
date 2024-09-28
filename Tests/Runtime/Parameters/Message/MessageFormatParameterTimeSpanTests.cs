using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Parameters.Message;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Parameters.Message
{
    [TestFixture]
    public class MessageFormatParameterTimeSpanTests
    {
        [TestCase("c")]
        [TestCase("g")]
        [TestCase("G")]
        [TestCase("")]
        public void Render_ShouldReturnCorrectFormattedTimeSpanString(string format)
        {
            var time = TimeSpan.Zero;
            var parameter = new MessageFormatParameterTimeSpan();

            var expected = time.ToString(format);
            var actual = parameter.Render(time, format).ToString();
            
            Assert.AreEqual(expected, actual);
        }
    }
}
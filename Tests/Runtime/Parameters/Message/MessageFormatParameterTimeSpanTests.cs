﻿using System;
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
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
            //Arrange
            var time = TimeSpan.Zero;
            var parameter = new MessageFormatParameterTimeSpan();
            var expected = time.ToString(format);
            var builder = new ValueStringBuilder();
            
            //Act
            parameter.Render(ref builder, time, format);
            
            //Assert
            Assert.AreEqual(expected, builder.ToString());
        }
    }
}
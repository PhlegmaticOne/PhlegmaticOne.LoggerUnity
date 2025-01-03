﻿using NUnit.Framework;
using Openmygame.Logger.Messages.Tagging;

namespace Openmygame.Logger.Tests.Runtime.Tagging
{
    [TestFixture]
    public class LogTagFormatTests
    {
        [Test]
        [TestCase("#{Tag}#", "{Tag}", "#", "#")]
        [TestCase("{Tag}", "{Tag}", "", "")]
        [TestCase("[#{Tag}#]", "{Tag}", "[#", "#]")]
        public void UpdateFormat_ShouldCorrectlyParseFormat(string tag, string formatExpected, string prefix, string postfix)
        {
            var format = new LogTagFormat(tag);
            
            Assert.AreEqual(prefix, format.Prefix);
            Assert.AreEqual(postfix, format.Postfix);
            Assert.AreEqual(formatExpected, format.Format);
        }
    }
}
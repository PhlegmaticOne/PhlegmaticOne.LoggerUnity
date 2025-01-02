using System.Collections.Generic;
using NUnit.Framework;
using Openmygame.Logger.Parsing;
using Openmygame.Logger.Parsing.Exceptions;

namespace Openmygame.Logger.Tests.Runtime.Parsing
{
    [TestFixture]
    public class MessageFormatParserTests
    {
        [TestCase("{Test")]
        [TestCase("Test}")]
        [TestCase("{Test}}")]
        [TestCase("{{}")]
        public void Parse_ShouldThrowException_WhenCountOnOpenBracesNotEqualToCountOfCloseBraces(string format)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            //Assert
            Assert.Throws<MessageFormatParseException>(() => parser.Parse(format));
        }
        
        [TestCase("")]
        [TestCase(null)]
        [TestCase("      ")]
        public void Parse_ShouldThrowException_WhenInputFormatIsEmptyString(string format)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            //Assert
            Assert.Throws<MessageFormatParseException>(() => parser.Parse(format));
        }

        [TestCase("Test")]
        [TestCase("Test string")]
        public void Parse_ShouldReturnOneMessagePart_WhenInputFormatHasNoParameters(string format)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            var messageFormat = parser.Parse(format);
            
            //Assert
            Assert.AreEqual(1, messageFormat.Length);
            Assert.IsFalse(messageFormat[0].IsParameter);
        }

        [TestCase("}}}{{{")]
        [TestCase("}}}{}{{{")]
        public void Parse_ShouldThrowException_WhenFormatDoesNotHaveFollowingCloseBrace(string format)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            //Assert
            Assert.Throws<MessageFormatParseException>(() => parser.Parse(format));
        }

        [TestCase("{Value}", 3)]
        [TestCase("Value {Value}", 3)]
        [TestCase("{Value} value", 3)]
        [TestCase("Value {Value} value", 3)]
        [TestCase("This log {Message} contains {Count} symbols", 5)]
        public void Parse_ShouldCreateMessagePartsCount2xPlus1FromParametersCount(string format, int expected)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            var messageParts = parser.Parse(format);
            
            //Assert
            Assert.AreEqual(expected, messageParts.Length);
        }
        
        [TestCaseSource(typeof(FormatsSource), nameof(FormatsSource.Get))]
        public void Parse_ShouldCreateSpecifiedMessageParts(FormatSourceTestCase testCase)
        {
            //Arrange
            var parser = new MessageFormatParser();
            
            //Act
            var messageParts = parser.Parse(testCase.Format);
            
            //Assert
            for (var i = 0; i < messageParts.Length; i++)
            {
                var expected = testCase.MessageParts[i];
                var actual = messageParts[i].GetValue().ToString();
                
                Assert.AreEqual(expected, actual);
            }
        }
    }

    internal class FormatsSource
    {
        public static IEnumerable<FormatSourceTestCase> Get()
        {
            yield return First();
            yield return Second();
            yield return Third();
            yield return Forth();
            yield return Fifth();
        }

        private static FormatSourceTestCase First()
        {
            const string format = "{Value}";

            return new FormatSourceTestCase(format, new[]
            {
                string.Empty,
                "Value",
                string.Empty,
            });
        }
        
        private static FormatSourceTestCase Second()
        {
            const string format = "Value {Value}";

            return new FormatSourceTestCase(format, new[]
            {
                "Value ",
                "Value",
                string.Empty,
            });
        }
        
        private static FormatSourceTestCase Third()
        {
            const string format = "{Value} value";

            return new FormatSourceTestCase(format, new[]
            {
                string.Empty,
                "Value",
                " value",
            });
        }
        
        private static FormatSourceTestCase Forth()
        {
            const string format = "Value {Value} value";

            return new FormatSourceTestCase(format, new[]
            {
                "Value ",
                "Value",
                " value",
            });
        }
        
        private static FormatSourceTestCase Fifth()
        {
            const string format = "This log {Message} contains {Count} symbols";

            return new FormatSourceTestCase(format, new[]
            {
                "This log ",
                "Message",
                " contains ",
                "Count",
                " symbols"
            });
        }
    }

    public class FormatSourceTestCase
    {
        public string Format { get; }
        public string[] MessageParts { get; }

        public FormatSourceTestCase(string format, string[] messageParts)
        {
            Format = format;
            MessageParts = messageParts;
        }

        public override string ToString()
        {
            return Format;
        }
    }
}
using NUnit.Framework;
using OpenMyGame.LoggerUnity.Tagging.Providers;

namespace OpenMyGame.LoggerUnity.Tests.Runtime.Tagging.Providers
{
    [TestFixture]
    public class LogTagProviderTests
    {
        [TestCase("Tag")]
        [TestCase("<color=#FFFFFF>Tag</color>")]
        public void FormatTag_ShouldCorrectlyFormatTag(string tagValue)
        {
            //Arrange
            const string tagFormat = "#{Tag}#";
            var provider = new LogTagProvider(tagFormat);
            var expected = $"#{tagValue}#";

            //Act
            var formatted = provider.FormatTag(tagValue);

            //Assert
            Assert.AreEqual(expected, formatted);
        }
        
        [Test]
        public void AddTagToFormat_ShouldCorrectlyAddTagFormatToString()
        {
            //Arrange
            const string tagFormat = "#{Tag}#";
            const string format = "{Message} with name {Name}";
            var provider = new LogTagProvider(tagFormat);
            var expected = $"{tagFormat} {format}";

            //Act
            var formatted = provider.AddTagToFormat(format);

            //Assert
            Assert.AreEqual(expected, formatted);
        }
    }
}
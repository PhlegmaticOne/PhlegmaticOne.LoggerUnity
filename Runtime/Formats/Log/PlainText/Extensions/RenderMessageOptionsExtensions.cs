using OpenMyGame.LoggerUnity.Configuration;
using OpenMyGame.LoggerUnity.Parsing;

namespace OpenMyGame.LoggerUnity.Formats.Log.PlainText
{
    public static class RenderMessageOptionsExtensions
    {
        public static void PlainText(this RenderMessageOptions messageOptions, string format = null)
        {
            var parser = new MessageFormatParser();
            var resultFormat = string.IsNullOrEmpty(format) ? LoggerConfigurationData.LogFormat : format;
            var messageParts = parser.Parse(resultFormat);
            messageOptions.FromFactory(new LogFormatFactoryPlainText(messageParts));
        }
    }
}
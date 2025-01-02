using Openmygame.Logger.Configuration;
using Openmygame.Logger.Parsing;

namespace Openmygame.Logger.Formats.Log.PlainText
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
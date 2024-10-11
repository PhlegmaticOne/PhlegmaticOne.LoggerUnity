using OpenMyGame.LoggerUnity.Base;
using OpenMyGame.LoggerUnity.Formats.Log.Factory;
using OpenMyGame.LoggerUnity.Formats.Log.PlainText;

namespace OpenMyGame.LoggerUnity.Formats
{
    public class RenderMessageOptions
    {
        private readonly LogConfiguration _logConfiguration;

        public RenderMessageOptions(LogConfiguration logConfiguration)
        {
            _logConfiguration = logConfiguration;
            this.PlainText(LoggerStaticData.LogFormat);
        }

        public void FromFactory(ILogFormatFactory logFormatFactory)
        {
            if (logFormatFactory is not null)
            {
                _logConfiguration.SetFormatsFactory(logFormatFactory);
            }
        }
    }
}
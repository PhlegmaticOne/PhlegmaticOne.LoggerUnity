using Openmygame.Logger.Base;
using Openmygame.Logger.Configuration;
using Openmygame.Logger.Formats.Log.Factory;
using Openmygame.Logger.Formats.Log.PlainText;

namespace Openmygame.Logger.Formats
{
    public class RenderMessageOptions
    {
        private readonly LogConfiguration _logConfiguration;

        public RenderMessageOptions(LogConfiguration logConfiguration)
        {
            _logConfiguration = logConfiguration;
            this.PlainText(LoggerConfigurationData.LogFormat);
        }
        
        public void FromFactory(ILogFormatFactory logFormatFactory)
        {
            if (logFormatFactory is not null)
            {
                _logConfiguration.SetFormatFactory(logFormatFactory);
            }
        }
    }
}
namespace Openmygame.Logger.Formats.Log.Factory
{
    public interface ILogFormatFactory
    {
        ILogFormat CreateLogFormat(LogFormatFactoryData factoryData);
    }
}
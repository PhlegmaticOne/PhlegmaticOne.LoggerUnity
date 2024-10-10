namespace OpenMyGame.LoggerUnity.Formats.Log.Factory
{
    public interface ILogFormatFactory
    {
        ILogFormat CreateLogFormat(MessageFormatsFactoryData factoryData);
    }
}
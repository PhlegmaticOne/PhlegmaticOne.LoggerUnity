namespace OpenMyGame.LoggerUnity.Formats.Log.Factory
{
    public interface ILogFormatFactory
    {
        /// <summary>
        /// Создает формат для формирования результирующего сообщения
        /// </summary>
        /// <param name="factoryData">Данные добавленные при конфигурации логгера</param>
        ILogFormat CreateLogFormat(LogFormatFactoryData factoryData);
    }
}
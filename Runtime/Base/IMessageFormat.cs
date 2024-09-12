namespace OpenMyGame.LoggerUnity.Runtime.Base
{
    public interface IMessageFormat
    {
        string Format { get; }
        string Render(LogMessage logMessage);
    }
}
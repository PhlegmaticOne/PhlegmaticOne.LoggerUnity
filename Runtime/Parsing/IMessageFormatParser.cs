namespace OpenMyGame.LoggerUnity.Runtime.Parsing
{
    public interface IMessageFormatParser
    {
        MessageFormat Parse(string format, object[] parameters);
    }
}
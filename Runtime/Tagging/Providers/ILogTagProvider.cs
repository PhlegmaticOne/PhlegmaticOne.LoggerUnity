namespace OpenMyGame.LoggerUnity.Tagging.Providers
{
    public interface ILogTagProvider
    {
        LogTag CreateTag(string tag);
        string FormatTag(string tag);
        string AddTagToFormat(string format);
    }
}
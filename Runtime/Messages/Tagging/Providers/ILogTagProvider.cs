namespace OpenMyGame.LoggerUnity.Messages.Tagging.Providers
{
    public interface ILogTagProvider
    {
        string FormatTag(string tag);
        string AddTagToFormat(string format);
    }
}
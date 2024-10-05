namespace OpenMyGame.LoggerUnity.Tagging.Providers
{
    public interface ILogTagProvider
    {
        string FormatTag(string tag);
        string AddTagToFormat(string format);
    }
}
namespace OpenMyGame.LoggerUnity.Tagging.Factories
{
    public interface ILogTagProvider
    {
        LogTag CreateTag(string tag);
        string AddTagToFormat(string format);
    }
}
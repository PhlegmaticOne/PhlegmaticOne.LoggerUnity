namespace OpenMyGame.LoggerUnity.Tagging.Factories
{
    public interface ILogWithTagFactory
    {
        LogWithTag Create(string tag);
    }
}
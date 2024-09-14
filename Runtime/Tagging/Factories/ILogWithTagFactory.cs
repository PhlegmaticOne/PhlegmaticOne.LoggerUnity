namespace OpenMyGame.LoggerUnity.Runtime.Tagging.Factories
{
    public interface ILogWithTagFactory
    {
        LogWithTag Create(string tag);
    }
}
namespace OpenMyGame.LoggerUnity.Runtime.Tagging.Factories
{
    public class LogWithTagFactory : ILogWithTagFactory
    {
        private readonly string _tagFormat;

        public LogWithTagFactory(string tagFormat)
        {
            _tagFormat = tagFormat;
        }
        
        public LogWithTag Create(string tag)
        {
            return new LogWithTag(tag, _tagFormat);
        }
    }
}
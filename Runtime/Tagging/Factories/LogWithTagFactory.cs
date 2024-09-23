using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Tagging.Factories
{
    internal class LogWithTagFactory : ILogWithTagFactory
    {
        private readonly string _tagFormat;
        private readonly bool _isColorize;

        public LogWithTagFactory(string tagFormat)
        {
            _tagFormat = tagFormat;
            _isColorize = MessagePart.Parameter(tagFormat).HasFormat("c");
        }
        
        public LogWithTag Create(string tag)
        {
            return new LogWithTag(tag, _tagFormat, _isColorize);
        }
    }
}
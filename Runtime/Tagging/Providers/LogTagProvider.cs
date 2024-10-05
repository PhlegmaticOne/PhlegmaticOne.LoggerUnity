namespace OpenMyGame.LoggerUnity.Tagging.Providers
{
    internal class LogTagProvider : ILogTagProvider
    {
        private readonly string _tagFormat;

        public LogTagProvider(string tagFormat)
        {
            _tagFormat = tagFormat;
        }

        public string FormatTag(string tag)
        {
            var tagFormat = _tagFormat.Replace(LogTag.TagKey, "0");
            return string.Format(tagFormat, tag);
        }

        public string AddTagToFormat(string format)
        {
            return $"{_tagFormat} {format}";
        }
    }
}
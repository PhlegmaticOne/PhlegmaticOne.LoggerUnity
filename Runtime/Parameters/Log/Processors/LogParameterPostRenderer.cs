using OpenMyGame.LoggerUnity.Parsing.Models;
using SpanUtilities.StringBuilders;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    internal class LogParameterPostRenderer : ILogParameterPostRenderer
    {
        public void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue) { }
        public void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart) { }
    }
}
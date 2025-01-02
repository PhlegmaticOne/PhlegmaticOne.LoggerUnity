using Openmygame.Logger.Infrastructure.StringBuilders;
using Openmygame.Logger.Parsing.Models;

namespace Openmygame.Logger.Parameters.Log.Processors
{
    internal class LogParameterProcessor : ILogParameterProcessor
    {
        public void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue) { }
        public void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart) { }
    }
}
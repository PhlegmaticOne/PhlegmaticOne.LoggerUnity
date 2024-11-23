using OpenMyGame.LoggerUnity.Infrastructure.StringBuilders;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    public interface ILogParameterProcessor
    {
        void Preprocess(ref ValueStringBuilder destination, in MessagePart messagePart, object parameterValue);
        void Postprocess(ref ValueStringBuilder destination, in MessagePart messagePart);
    }
}
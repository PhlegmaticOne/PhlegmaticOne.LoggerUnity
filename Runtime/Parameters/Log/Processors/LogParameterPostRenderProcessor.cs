using System;
using System.Text;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    public class LogParameterPostRenderProcessor : ILogParameterPostRenderProcessor
    {
        public void Process(StringBuilder destination, in MessagePart messagePart, in ReadOnlySpan<char> renderedValue)
        {
            destination.Append(renderedValue);
        }
    }
}
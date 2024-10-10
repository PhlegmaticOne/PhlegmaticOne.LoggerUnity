using System;
using System.Text;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    internal class LogParameterPostRenderer : ILogParameterPostRenderer
    {
        public void Process(StringBuilder destination, in MessagePart messagePart, in ReadOnlySpan<char> renderedValue)
        {
            destination.Append(renderedValue);
        }
    }
}
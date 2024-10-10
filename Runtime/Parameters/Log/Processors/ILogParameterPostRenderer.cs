using System;
using System.Text;
using OpenMyGame.LoggerUnity.Parsing.Models;

namespace OpenMyGame.LoggerUnity.Parameters.Log.Processors
{
    public interface ILogParameterPostRenderer
    {
        void Process(StringBuilder destination, in MessagePart messagePart, in ReadOnlySpan<char> renderedValue);
    }
}
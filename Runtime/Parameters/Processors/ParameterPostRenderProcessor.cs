using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Processors.Colors
{
    internal class ParameterPostRenderProcessor : IParameterPostRenderProcessor
    {
        public void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter)
        {
            destination.Append(renderedParameter);
        }
    }
}
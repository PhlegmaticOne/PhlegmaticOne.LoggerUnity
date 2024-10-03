using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Processors
{
    public interface IParameterPostRenderProcessor
    {
        void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter);
    }
}
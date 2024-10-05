using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    internal class MessageParameterPostRenderProcessor : IMessageParameterPostRenderProcessor
    {
        public void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter)
        {
            destination.Append(renderedParameter);
        }
    }
}
using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    internal class MessageParameterPostRenderer : IMessageParameterPostRenderer
    {
        public void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter)
        {
            destination.Append(renderedParameter);
        }
    }
}
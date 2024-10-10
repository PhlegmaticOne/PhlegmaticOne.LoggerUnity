using System;
using System.Text;

namespace OpenMyGame.LoggerUnity.Parameters.Message.Processors
{
    public interface IMessageParameterPostRenderer
    {
        void Process(StringBuilder destination, in ReadOnlySpan<char> renderedParameter, object parameter);
    }
}